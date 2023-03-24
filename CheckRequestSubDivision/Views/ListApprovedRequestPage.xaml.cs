using CheckRequestSubDivision.Models;
using CheckRequestSubDivision.ViewModels;
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

namespace CheckRequestSubDivision.Views
{
    /// <summary>
    /// Логика взаимодействия для ListApprovedRequest.xaml
    /// </summary>
    public partial class ListApprovedRequestPage : Page
    {
        public ListApprovedRequestPage(int subDivisionId)
        {
            InitializeComponent();
            DataContext = new ListApprovedRequestPageVM(subDivisionId);
        }

        private void OpenModalWindow(object sender, MouseButtonEventArgs e)
        {
            ((ListApprovedRequestPageVM)DataContext).OpenModalWindow();
        }
    }
}
