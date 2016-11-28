using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EDDitor
{
    class OpenedFile
    {
        public StackPanel spTextSpace { get; set; }
        public bool ReadyToMerge
        {
            get
            {
                StackPanel spControl = spTextSpace.Children[0] as StackPanel;
                CheckBox cbReadyToMerge = spControl.Children[3] as CheckBox;
                return cbReadyToMerge.IsChecked == true;
            }
        }
        public string Content
        {
            get
            {
                TextBox txtContent = spTextSpace.Children[1] as TextBox;
                return txtContent.Text;
            }
            set
            {
                TextBox txtContent = spTextSpace.Children[1] as TextBox;
                txtContent.Text = value;
            }
        }

        public OpenedFile(RoutedEventHandler removeEvent, string content = "")
        {
            spTextSpace = new StackPanel();
            spTextSpace.Margin = new Thickness(15);

            TextBox txtFileContent = new TextBox();
            txtFileContent.MinHeight = 50;
            txtFileContent.AcceptsReturn = true;
            txtFileContent.Text = content;

            StackPanel spControl = new StackPanel();
            spControl.Orientation = Orientation.Horizontal;
            spControl.HorizontalAlignment = HorizontalAlignment.Right;

            //create buttons
            Button btnRemove = CreateButton("x");
            btnRemove.Click += removeEvent;
            spControl.Children.Add(btnRemove);

            Button btnSave = CreateButton("s");
            spControl.Children.Add(btnSave);

            Button btnSaveAs = CreateButton("ax");
            spControl.Children.Add(btnSaveAs);

            CheckBox readyToMerger = new CheckBox();
            readyToMerger.Margin = new Thickness(10, 0, 0, 0);
            spControl.Children.Add(readyToMerger);

            //add text and buttons to block. And add him to the main panel
            spTextSpace.Children.Add(spControl);
            spTextSpace.Children.Add(txtFileContent);
        }    

        private Button CreateButton(string name)
        {
            Button btn = new Button();
            btn.Content = name;
            btn.Margin = new Thickness(10, 0, 0, 0);
            return btn;
        }
    }
}