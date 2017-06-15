using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using zlib;

namespace Oti.Sas.ContractDesigner {
    public class Helper {
        public static IEnumerable<byte> GetBytes(int value, int length) {
            var bytes = BitConverter.GetBytes(value).Reverse().SkipWhile(x => x == 0).ToArray();
            if (bytes.Length >= length) return bytes;

            const byte b = 0;
            return Enumerable.Repeat(b, length - bytes.Length).Concat(bytes);
        }

        public static byte[] Compress(string str) {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var outMemoryStream = new MemoryStream())
            using (var outZStream = new ZOutputStream(outMemoryStream, zlibConst.Z_DEFAULT_COMPRESSION))
            using (var inMemoryStream = new MemoryStream(bytes)) {
                CopyStream(inMemoryStream, outZStream);
                outZStream.finish();
                return outMemoryStream.ToArray();
            }
        }

        public static string Decompress(byte[] inData) {
            using (var outMemoryStream = new MemoryStream())
            using (var outZStream = new ZOutputStream(outMemoryStream))
            using (var inMemoryStream = new MemoryStream(inData)) {
                CopyStream(inMemoryStream, outZStream);
                outZStream.finish();
                var outData = outMemoryStream.ToArray();

                return Encoding.UTF8.GetString(outData);
            }
        }

        public static void CopyStream(Stream input, Stream output) {
            var buffer = new byte[2000];
            int len;
            while ((len = input.Read(buffer, 0, 2000)) > 0) {
                output.Write(buffer, 0, len);
            }
            output.Flush();
        }
    }
}
