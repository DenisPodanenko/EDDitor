using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;

namespace EDDitor
{
    public partial class MainWindow : Window
    {
        //events textBlock
        private void closeFile(object sender, RoutedEventArgs e)
        {
            StackPanel spClosingFile = getCurrentFile(sender as Button).spTextSpace; //get needed parent element

            for (int i = 0; i < openedFiles.Count; i++)
            {
                if (openedFiles[i].spTextSpace == spClosingFile)
                {
                    spMain.Children.Remove(openedFiles[i].spTextSpace);
                    openedFiles.Remove(openedFiles[i]);
                }
            }
        }
        private void saveFile(object sender, RoutedEventArgs e)
        {
            //File.WriteAllText(path , tbt.Text);
        }
        private void saveFileAs(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text documents (.txt)|*.txt|Word doc (.DOCM)|*.DOMC";
            saveFileDialog1.Title = "Save an Text File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {

                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
 
                fs.Close();
            }
        }
    }
}