using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ProcessInfo_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List <Process> processes = Process.GetProcesses().ToList();
            foreach (Process pr in processes) {
                PocessLB.Items.Add (pr.Id +" "+ pr.ProcessName);
            }
        }

        private void PocessLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { 
            if(PocessLB.SelectedItem != null)
            {
                InfoProcess win = new InfoProcess();
                string []spl = PocessLB.SelectedItem.ToString().Split(' ');
                Process cr = Process.GetProcessById(Convert.ToInt32(spl[0]));
                win.AllInfoLB.Items.Add( "Id процесса - "+cr.Id);
                win.AllInfoLB.Items.Add("Имя процесса - " + cr.ProcessName);
                win.AllInfoLB.Items.Add("Приоритет процесса - " + cr.PriorityClass);
                win.AllInfoLB.Items.Add("Значение приоритета процесса - " + cr.BasePriority);
                win.AllInfoLB.Items.Add("Инфо о старте процесса - " + cr.StartInfo);
                win.AllInfoLB.Items.Add("Id-сессии процесса - " + cr.SessionId);
                win.ShowDialog();
                }
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }
    }
}
