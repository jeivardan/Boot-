using System;
using System.Collections.Generic;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;



namespace Application
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            usb();
        }
        public string usb()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string str="";
            foreach (DriveInfo d in allDrives)
            {   
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        d.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        d.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        d.TotalSize);
                    if(d.Name != "C:\\")
                        device.Items.Add(d.VolumeLabel);
                    str = d.VolumeLabel;
                }
            }
            return str;
        }
        private OpenFileDialog openFileDialog1;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var item in device.Items)
            {
                string str = usb();
                if (str != (string)item)
                    device.Items.Add(str);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.ShowDialog();
            MessageBox.Show(opn.FileName);
            textbox2.Text = System.IO.Path.GetFileName(opn.FileName);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
