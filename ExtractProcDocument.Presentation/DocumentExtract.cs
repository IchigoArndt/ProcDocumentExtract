using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractProcDocument.Presentation
{
    public static class DocumentExtract
    {
        static string DocumentOriginal;
        public static string documentOriginal(string tpDocument,string procDocument)
        {
            var proc = procDocument;
            if (tpDocument.Equals("CTe"))
            {
                var indexStart = proc.IndexOf("<CTe");
                var indexEnd = proc.IndexOf("<Signature ");
                var text = proc.Substring(indexStart, indexEnd);
                indexEnd = text.IndexOf("<Signature ");
                text = text.Remove(indexEnd);
                DocumentOriginal = "<enviCTe xmlns=\"http://www.portalfiscal.inf.br/cte\" versao=\"3.00\"><idLote>000000000000001</idLote>";
                DocumentOriginal += "\n" + text;
                DocumentOriginal += "\n" + "</CTe>" + "\n" + "</enviCTe>";
            } else if (tpDocument.Equals("NFe"))
            {
                var indexStart = proc.IndexOf("<NFe");
                var indexEnd = proc.IndexOf("<Signature ");
                var text = proc.Substring(indexStart, indexEnd);
                indexEnd = text.IndexOf("<Signature ");
                text = text.Remove(indexEnd);
                DocumentOriginal = "<enviNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"4.00\"><idLote>000000000000001</idLote>";
                DocumentOriginal += "\n" + text;
                DocumentOriginal += "\n" + "</NFe>" + "\n" + "</enviNFe>";
            }
            else
            {
                var indexStart = proc.IndexOf("<MDFe");
                var indexEnd = proc.IndexOf("<Signature ");
                var text = proc.Substring(indexStart, indexEnd);
                indexEnd = text.IndexOf("<Signature ");
                text = text.Remove(indexEnd);
                DocumentOriginal = "<enviMDFe xmlns=\"http://www.portalfiscal.inf.br/mdfe\" versao=\"3.00\"><idLote>000000000000001</idLote>";
                DocumentOriginal += "\n" + text;
                DocumentOriginal += "\n" + "</MDFe>" + "\n" + "</enviMDFe>";
            }
            return DocumentOriginal;
        }
    }
}
