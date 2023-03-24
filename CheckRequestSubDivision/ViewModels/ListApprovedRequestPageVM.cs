using CheckRequestSubDivision.DB;
using CheckRequestSubDivision.Models;
using CheckRequestSubDivision.Tools;
using CheckRequestSubDivision.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckRequestSubDivision.ViewModels
{
    public class ListApprovedRequestPageVM : BaseVM
    {
        private List<Request> requests;
        private Request selectedRequest;
        private DateTime selectedDateVisit;
        private int subDivisionId;

        public DateTime SelectedDateVisit 
        { 
            get => selectedDateVisit;
            set
            {
                selectedDateVisit = value;

                SignalChanged();
                DoSearch();
            }
        }

        public List<Request> Requests
        {
            get => requests;
            set
            {
                requests = value;
                SignalChanged();
            }

        }

        public Request SelectedRequest
        {
            get => selectedRequest;
            set
            {
                selectedRequest = value;
                SignalChanged();
            }
        }

        public ListApprovedRequestPageVM(int subDivisionId)
        {
            this.subDivisionId = subDivisionId;
            SelectedDateVisit = DateTime.Now;
            Requests = new List<Request>(GetRequests(subDivisionId));
                
        }

        public void OpenModalWindow()
        {
            var window = new ModalVindow(selectedRequest);
            window.ShowDialog();
        }

        private void DoSearch()
        {
            IQueryable<Request> searchRequest = GetRequests(subDivisionId);

            if (SelectedDateVisit != null)
                Requests = searchRequest.Where(s => s.DateVisit.Value.Date == SelectedDateVisit.Date).ToList();
            else
                Requests = searchRequest.ToList();
        }

        private static IQueryable<Request> GetRequests(int subDivisionId)
        {
            return user50_2Context.GetInstanse().Requests
                .Include(s => s.Worker).ThenInclude(s => s.SubDivision)
                .Include(s => s.VisitorsRequests).ThenInclude(s => s.Visitors)
                .ThenInclude( s => s.VisitorsVisits)
                .ThenInclude( s => s.Visit)
                .Include(s => s.Status)
                .Where(s => s.Worker.SubDivisionId == subDivisionId && s.StatusId == 2);
        }

    }
}
