
namespace Oti.Sas.ContractDesigner {
    class ComboBoxItem {
        private ComboBoxItem()
        {
            Value = null;
            Text = string.Empty;
        }

        public ComboBoxItem(string text, object value)
        {
            Text = text;
            Value = value;
        }
        public object Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
