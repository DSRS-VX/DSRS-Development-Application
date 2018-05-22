using Microsoft.Win32;
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
using System.IO;
using System.Diagnostics;

namespace DSRS_Development_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            NProject.Visibility = Visibility.Visible;
        }

        private void NProject_Click(object sender, RoutedEventArgs e)
        {
            PProject.Visibility = Visibility.Visible;
            JProject.Visibility = Visibility.Visible;
        }
        private void Python_Click(object sender, RoutedEventArgs e)
        {
            PProject.Visibility = Visibility.Collapsed;
            NProject.Visibility = Visibility.Collapsed;
            JProject.Visibility = Visibility.Collapsed;
            IDE.Text = "print 'Hello World!'\n\n" + "print 'Press Enter to Exit'\n" + "#KEEP PYTHON OPEN\n" + "raw_input()";
            BUILD.Visibility = Visibility.Visible;
            READONLY.Visibility = Visibility.Visible;
            SAVE.Visibility = Visibility.Visible;
            string path = Environment.CurrentDirectory + "/" + "PyFile.py";
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.CreateText(path);
                MessageBox.Show("Python Project Created Successfully, Projects can be found in the working directory under Projects");
            }
        }
        private void RD_Click(object sender, RoutedEventArgs e)
        {
            if (IDE.IsReadOnly == true)
            {
                IDE.IsReadOnly = false;
            }
            else
                IDE.IsReadOnly = true;
        }
        private void BA_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "Python.exe";
            startInfo.Arguments = "PyFile.py";
            Process.Start(startInfo.FileName, startInfo.Arguments);
        }

        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory + "/" + "PyFile.py";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(IDE.Text);
            }
        }

        private void Java_Click(object sender, RoutedEventArgs e)
        {
            PProject.Visibility = Visibility.Collapsed;
            NProject.Visibility = Visibility.Collapsed;
            JProject.Visibility = Visibility.Collapsed;
            IDE.Text = "/* JAVA FILE */\n\n" + "public class JFile\n" + "{\n" + " public static void main(String[] args) {\n" + "/* IN WPF YOU CAN NOT HAVE DOUBLE QUOTES INSIDE DOUBLE QUOTES SO YOU WILL MANUALLY HAVE TO EDIT THE HELLO WORLD CODE SO CHANGE THE SINGLE QUOTES TO DOUBLE QUOTES BEFORE AND AFTER TO FIX THE PROJECT */\n" + "  System.out.println('Hello World!');\n" + " }\n" + "}";
            BUILDJ.Visibility = Visibility.Visible;
            BUILDJR.Visibility = Visibility.Visible;
            READONLY.Visibility = Visibility.Visible;
            SAVEJ.Visibility = Visibility.Visible;
            string path = Environment.CurrentDirectory + "/" + "JFile.java";
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.CreateText(path);
                MessageBox.Show("Java Project Created Successfully, Projects can be found in the working directory under Projects");
            }
        }
        private void BJ_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "C:/Program Files/Java/jdk-10/bin/javac.exe";
            startInfo.Arguments = "JFile.java";
            Process.Start(startInfo.FileName, startInfo.Arguments);
        }
        private void SAVEJ_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory + "/" + "JFile.java";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(IDE.Text);
            }
        }
        private void JR_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "java.exe";
            startInfo.Arguments = "JFile";
            Process.Start(startInfo.FileName, startInfo.Arguments);
        }
    }
}

