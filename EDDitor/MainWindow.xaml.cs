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

namespace EDDitor
{
    public partial class MainWindow : Window
    {
        List<OpenedFile> openedFiles = new List<OpenedFile>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void clickBtnCreate(object sender, RoutedEventArgs e)
        {
            OpenedFile newFile = new OpenedFile(closeFile);
            spMain.Children.Add(newFile.spTextSpace);
            openedFiles.Add(newFile);
        }

        private void clickBtnMerge(object sender, RoutedEventArgs e)
        {
            StringBuilder content = new StringBuilder();

            foreach (var file in openedFiles)
            {
                if (file.ReadyToMerge)
                {
                    content.Append(file.Content + "\n");
                }
            }

            if (content.ToString() != "")
            {
                OpenedFile newFile = new OpenedFile(closeFile, content.ToString());
                spMain.Children.Add(newFile.spTextSpace);
                openedFiles.Add(newFile);
            }
        }

        //events textBlock
        private void closeFile(object sender, RoutedEventArgs e)
        {
            StackPanel spClosingFile = (((sender as Button).Parent as StackPanel).Parent as StackPanel); //get needed parent element
            
            for (int i = 0; i < openedFiles.Count; i++)
            {
                if(openedFiles[i].spTextSpace == spClosingFile)
                {
                    spMain.Children.Remove(openedFiles[i].spTextSpace);
                    openedFiles.Remove(openedFiles[i]);
                }
            }
        }
    }
}