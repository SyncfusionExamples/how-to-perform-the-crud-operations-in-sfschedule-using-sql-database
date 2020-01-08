using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ScheduleSample
{
    public class ScheduleMeeting : INotifyPropertyChanged
    {
        private string mappedSubject;
        public string MappedSubject
        {
            get { return this.mappedSubject; }

            set
            {
                if (this.mappedSubject == value)
                {
                    return;
                }
                this.mappedSubject = value;
                OnPropertyChanged("MappedSubject");
            }
        }

        private string appointmentID;
        public string AppointmentID
        {
            get { return this.appointmentID; }

            set
            {
                if (this.appointmentID == value)
                {
                    return;
                }
                this.appointmentID = value;
                OnPropertyChanged("AppointmentID");
            }
        }

        private DateTime mappedStartTime;
        public DateTime MappedStartTime
        {
            get { return this.mappedStartTime; }

            set
            {
                if (this.mappedStartTime == value)
                {
                    return;
                }
                this.mappedStartTime = value;
                OnPropertyChanged("MappedStartTime");
            }
        }

        private DateTime mappedEndTime;
        public DateTime MappedEndTime
        {
            get { return this.mappedEndTime; }

            set
            {
                if (this.mappedEndTime == value)
                {
                    return;
                }
                this.mappedEndTime = value;
                OnPropertyChanged("MappedEndTime");
            }
        }
        private Brush mappedColor;
        public Brush MappedColor
        {
            get { return this.mappedColor; }

            set
            {
                if (this.mappedColor == value)
                {
                    return;
                }
                this.mappedColor = value;
                OnPropertyChanged("MappedColor");
            }
        }
        private bool mappedIsAllDay;
        public bool MappedIsAllDay
        {
            get { return this.mappedIsAllDay; }

            set
            {
                if (this.mappedIsAllDay == value)
                {
                    return;
                }
                this.mappedIsAllDay = value;
                OnPropertyChanged("MappedIsAllDay");
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
