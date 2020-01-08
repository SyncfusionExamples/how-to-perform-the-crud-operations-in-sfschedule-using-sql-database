using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ScheduleSample
{
    public class ScheduleViewModel : INotifyPropertyChanged
    {
        MeetingsDBDataContext MeetingsDBDataContext;
        private ObservableCollection<ScheduleMeeting> meetings;
        public ObservableCollection<ScheduleMeeting> Meetings
        {
            get { return this.meetings; }

            set
            {
                if (this.meetings == value)
                {
                    return;
                }
                this.meetings = value;
                OnPropertyChanged("Meetings");
            }
        }
        public ScheduleViewModel()
        {
            Meetings = new ObservableCollection<ScheduleMeeting>();

            MeetingsDBDataContext = new MeetingsDBDataContext();
            var MeetingsList = (from data in MeetingsDBDataContext.Meeting_Tables
                                select data).ToList();

            for (int i = 0; i < MeetingsList.Count; i++)
            {
                Meetings.Add(new ScheduleMeeting()
                {
                    MappedSubject = MeetingsList[i].Subject,
                    MappedStartTime = Convert.ToDateTime(MeetingsList[i].StartTime),
                    MappedEndTime = Convert.ToDateTime(MeetingsList[i].EndTime),
                    MappedColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(MeetingsList[i].Color)),
                    MappedIsAllDay = Convert.ToBoolean(MeetingsList[i].IsAllDay),
                    AppointmentID = MeetingsList[i].ID.ToString()
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
