using CheckRequestSubDivision.DB;
using CheckRequestSubDivision.Models;
using CheckRequestSubDivision.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckRequestSubDivision.ViewModels
{
    public class ModalVindowVM : BaseVM
    {
        private bool block;
        private bool block2;
        private Visit visit;
        private const int time = 30;

        public Visit Visit 
        { 
            get => visit;
            set
            {
                visit = value;
                SignalChanged();
            }
        }

        public bool Block
        {
            get => block;
            set
            {
                block = value;
                SignalChanged();
            }
        }
        public bool Block2
        {
            get => block2;
            set
            {
                block2 = value;
                SignalChanged();
            }
        }

        public Command Welcome { get; set; }
        public Command NotWelcome { get; set; }


        public Request Request { get; set; }
        public ModalVindowVM(Models.Request selectedRequest)
        {
            Request = selectedRequest;
            VisitorsVisit visitorsVisit = selectedRequest.VisitorsRequests.First().Visitors.VisitorsVisits.FirstOrDefault(s => s.Visit.DateEnd == null);
            if (visitorsVisit != null)
            {
                if (visitorsVisit.Visit.TimeStartSubDivision == null)
                    Block = true;
                else if(visitorsVisit.Visit.TimeFinishSubDivision == null)
                    Block2 = true;
                Visit = visitorsVisit.Visit;
            }
            Welcome = new Command(() =>
            {
                Visit.TimeStartSubDivision = DateTime.Now;
                if((visit.TimeStartSubDivision - visit.DateStart).Value.Minutes > time)
                {
                    MessageBox.Show("Расстрел на месте");
                }
                SignalChanged(nameof (Visit));
                user50_2Context.GetInstanse().Visits.Update(Visit);
                user50_2Context.GetInstanse().SaveChanges();
                Block = false;
                Block2 = true;
            });

            NotWelcome = new Command(() =>
            {
                Visit.TimeFinishSubDivision = DateTime.Now;
                SignalChanged(nameof(Visit));
                user50_2Context.GetInstanse().Visits.Update(Visit);
                user50_2Context.GetInstanse().SaveChanges();
                Block2 = false;
            });
        }
    }
}
