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
using System.Windows.Shapes;

namespace CheckRequestSubDivision.Views
{
    /// <summary>
    /// Логика взаимодействия для ModalVindow.xaml
    /// </summary>
    public partial class ModalVindow : Window
    {
        public ModalVindow(Models.Request selectedRequest)
        {
            InitializeComponent();
            DataContext = new ModalVindowVM(selectedRequest);
        }
    }
}
