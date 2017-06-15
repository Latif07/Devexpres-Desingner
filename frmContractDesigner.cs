using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Oti.Sas.ContractDesigner.ContractService;

namespace Oti.Sas.ContractDesigner {
    public partial class frmContractDesigner : Form {
        public static XtraReport xreport;

        public frmContractDesigner () {
            InitializeComponent();
        }

        private static Contract SelectedContract { get; set; }
        private static string Credential { get; set; }
        private static string UserName { get; set; }

        private ContractServiceClient GetServiceClient () {
            return new ContractServiceClient("BasicHttpBinding_IContractService");
        }

        private void ClearScreen() {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cmbContracts.SelectedIndex = -1;
            grbxLogin.Enabled = !grbxContracts.Enabled;
        }

        private void frmContractDesigner_Load (object sender, EventArgs e) {
            grbxContracts.Enabled = false;
            ClearScreen();
        }
        private void bntLogin_Click (object sender, EventArgs e) {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) {
                MessageBox.Show("Login information must be provided", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Credential = GetCredentialToken(username, password);

            if (!string.IsNullOrWhiteSpace(Credential)) {
                grbxContracts.Enabled = true;
                ClearScreen();
                var result = GetContracts(Credential);
                foreach (var contract in result) {
                    cmbContracts.Items.Add(new ComboBoxItem(contract.Name, contract));
                }
            }
            else {
                MessageBox.Show("Login failed for the given information. Please try again.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void cmbContracts_SelectedIndexChanged (object sender, EventArgs e) {
            if (cmbContracts.SelectedIndex >= 0) {
                SelectedContract = (Contract) ((ComboBoxItem)cmbContracts.SelectedItem).Value;
            }
        }

        private void btnContract_Click (object sender, EventArgs e) {
            var contract = GetContract(Credential, SelectedContract.Id);

            if (!string.IsNullOrWhiteSpace(contract.ErrorInfo)) {
                MessageBox.Show(contract.ErrorInfo, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (contract.Data == null || contract.Data.Length <= 0) {
                MessageBox.Show("Couldn't get the contract info", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                LockContract(Credential, SelectedContract.Id);
                ShowReportDesigner(Credential, contract.Data[0].Content, contract.Data[0].Id);
            }

        }

        private string GetCredentialToken(string username, string password) {
            Cursor = Cursors.WaitCursor;
            var client = GetServiceClient();
            var result = string.Empty;
            try {
                result = client.Login(username, password, Language.English);
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message, "ERORR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                client.Close();
                Cursor = Cursors.Default;
            }
            return result;            
        }

        private List<Contract> GetContracts(string token) {
            Cursor = Cursors.WaitCursor;
            var contracts = new List<Contract>();
            var client = GetServiceClient();
            try {
                var serviceResult = (client.GetContracts(token));
                contracts = new List<Contract>(serviceResult.Data);
                if (!string.IsNullOrWhiteSpace(serviceResult.ErrorInfo)) {
                    MessageBox.Show(serviceResult.ErrorInfo, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null; 
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                client.Close();
                Cursor = Cursors.Default;
            }
            return contracts;
        }

        private ContractResponse GetContract(string token, int contractTemplateId) {
            Cursor = Cursors.WaitCursor;
            var result = new ContractResponse();
            var client = GetServiceClient();
            try {
                result = client.GetContract(token, contractTemplateId);
              
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                client.Close();
                Cursor = Cursors.Default;
            }
            return result;
        }
        private void UnLockContract (string token, int contractId) {
            Cursor = Cursors.WaitCursor;
            var client = GetServiceClient();
            try {
                var result = client.Unlock(token, contractId);
                if (string.IsNullOrWhiteSpace(result.ErrorInfo)) return;
                MessageBox.Show(result.ErrorInfo, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                client.Close();
                Cursor = Cursors.Default;
            }
        }

        private void LockContract (string token, int contractId) {
            Cursor = Cursors.WaitCursor;
            var client = GetServiceClient();
            try {
                var result = client.Lock(token, contractId);
                if (string.IsNullOrWhiteSpace(result.ErrorInfo)) return;
                MessageBox.Show(result.ErrorInfo, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                client.Close();
                Cursor = Cursors.Default;
            }
        }

        private void ShowReportDesigner(string token, string reportContent, int contractId) {
            // Create a design form and get its MDI controller.
            XRDesignForm form = new XRDesignForm();
            mdiController = form.DesignMdiController;

            // Handle the DesignPanelLoaded event of the MDI controller,
            // to override the SaveCommandHandler for every loaded report.
            mdiController.DesignPanelLoaded +=
                new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);

            // Open an empty report in the form.
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(reportContent))) {
                xreport = XtraReport.FromStream(stream, true);
                mdiController.OpenReport(xreport);

                form.ActiveDesignPanel.SetCommandVisibility(ReportCommand.NewReport, CommandVisibility.None);
                form.ActiveDesignPanel.SetCommandVisibility(ReportCommand.OpenFile, CommandVisibility.None);
                form.ActiveDesignPanel.SetCommandVisibility(ReportCommand.SaveAll, CommandVisibility.None);
                form.ActiveDesignPanel.SetCommandVisibility(ReportCommand.ShowScriptsTab, CommandVisibility.None);
                form.ActiveDesignPanel.SetCommandVisibility(ReportCommand.NewReportWizard, CommandVisibility.None);
                form.ActiveDesignPanel.SetCommandVisibility(ReportCommand.SaveFileAs, CommandVisibility.None);
                form.ActiveDesignPanel.SetCommandVisibility(ReportCommand.Close, CommandVisibility.None);
            }
            // Show the form.
            form.WindowState = FormWindowState.Maximized;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            if (mdiController.ActiveDesignPanel != null) {
                UnLockContract(token, contractId);
                mdiController.ActiveDesignPanel.CloseReport();
            }
            
        }

        // Create an MDI (multi-document interface) controller instance.
        XRDesignMdiController mdiController;

        void mdiController_DesignPanelLoaded (object sender, DesignerLoadedEventArgs e) {
            XRDesignPanel panel = (XRDesignPanel)sender;
            panel.AddCommandHandler(new SaveCommandHandler(panel));
        }

        public class SaveCommandHandler : ICommandHandler {
            XRDesignPanel panel;

            public SaveCommandHandler (XRDesignPanel panel) {
                this.panel = panel;
            }

            public void HandleCommand (ReportCommand command, object[] args) {
                // Save the report.
                Save();
            }

            public bool CanHandleCommand (ReportCommand command, ref bool useNextHandler) {
                useNextHandler = !(command == ReportCommand.SaveFile ||
                    command == ReportCommand.SaveFileAs);
                return !useNextHandler;
            }

            void Save () {
                // Write your custom saving here.
                // ...
                if (xreport != null) {
                    string result = string.Empty;

                    using (var stream = new MemoryStream()) {
                        xreport.SaveLayoutToXml(stream);
                        stream.Seek(0, SeekOrigin.Begin);
                        result = new StreamReader(stream).ReadToEnd();
                    }

                    var client = new ContractServiceClient();
                    var compressedData = Helper.Compress(result);

                    var saveResult = client.SaveContract(Credential, UserName, SelectedContract.Id, compressedData);

                    if (!string.IsNullOrWhiteSpace(saveResult.ErrorInfo)) {
                        MessageBox.Show(saveResult.ErrorInfo, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Prevent the "Report has been changed" dialog from being shown.
                    panel.ReportState = ReportState.Saved;
                }
            }
        }

        private void frmContractDesigner_KeyUp (object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                Close();
            }
        }

        private void btnLogout_Click (object sender, EventArgs e) {
            Credential = String.Empty;
            grbxContracts.Enabled = false;
            ClearScreen();
        }

    }
}
