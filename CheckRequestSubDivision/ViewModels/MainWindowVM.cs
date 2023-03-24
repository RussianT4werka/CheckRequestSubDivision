using CheckRequestSubDivision.Tools;
using CheckRequestSubDivision.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CheckRequestSubDivision.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        private Page currentPage;

        public MainWindowVM()
        {
            currentPage = new SignInPage(this);
        }

        public Page CurrentPage 
        { 
            get => currentPage;
            set
            {
                currentPage = value;
                SignalChanged();
            }

        }
    }
}
