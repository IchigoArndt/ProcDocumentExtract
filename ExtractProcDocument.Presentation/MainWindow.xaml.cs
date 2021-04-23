using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ExtractProcDocument.Presentation
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtDocument.IsEnabled = true;
            txtDocument.IsReadOnly = true;
        }

        private void BtnExtract_Click(object sender, RoutedEventArgs e)
        {
            var proc = new TextRange(txtProc.Document.ContentStart, txtProc.Document.ContentEnd);
            chkNFe.IsChecked = proc.Text.Contains("nNF");
            chkCTe.IsChecked = proc.Text.Contains("nCT");
            chkMDFe.IsChecked = proc.Text.Contains("nMDF");

            if ((proc.Text != null)&&(proc.Text != string.Empty))
            {
                if (chkCTe.IsChecked != false)
                {
                    txtDocument.Text = DocumentExtract.documentOriginal("CTe", proc.Text.ToString());
                }
                else if (chkNFe.IsChecked != false)
                {
                    txtDocument.Text = DocumentExtract.documentOriginal("NFe", proc.Text.ToString());
                }
                else
                {
                    txtDocument.Text = DocumentExtract.documentOriginal("MDFe", proc.Text.ToString());
                }
            }
            else
            {
                MessageBox.Show("Proc Vazio !");
            }
        }

        private void ChkNFe_Checked(object sender, RoutedEventArgs e)
        {
            if (chkNFe.IsChecked == true)
            {
                chkCTe.IsEnabled = false;
                chkMDFe.IsEnabled = false;
            }
            else
            {
                chkCTe.IsEnabled = true;
                chkMDFe.IsEnabled = true;
            }
        }

        private void ChkCTe_Checked(object sender, RoutedEventArgs e)
        {
            if (chkCTe.IsChecked == true)
            {
                chkNFe.IsEnabled = false;
                chkMDFe.IsEnabled = false;
            }
            else
            {
                chkNFe.IsEnabled = true;
                chkMDFe.IsEnabled = true;
            }
        }

        private void ChkMDFe_Checked(object sender, RoutedEventArgs e)
        {
            if (chkMDFe.IsChecked == true)
            {
                chkCTe.IsEnabled = false;
                chkNFe.IsEnabled = false;
            }
            else
            {
                chkNFe.IsEnabled = true;
                chkCTe.IsEnabled = true;
            }
        }
    }
}
