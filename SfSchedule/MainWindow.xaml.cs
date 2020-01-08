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

namespace ScheduleSample
{
    using System.Collections.ObjectModel;
    using Syncfusion.UI.Xaml.Schedule;
    using System.Reflection;
    using System.ComponentModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            schedule.AppointmentEditorClosed += Schedule_AppointmentEditorClosed;
        }

        private void Schedule_AppointmentEditorClosed(object sender, AppointmentEditorClosedEventArgs e)
        {

            MeetingsDBDataContext scheduleMeetings = new MeetingsDBDataContext();
            Meeting_Table meeting;
           

            if (e.Action == EditorClosedAction.Save)
            {
                var editedAppointment = (e.EditedAppointment as ScheduleMeeting);
                var appointmentID = Convert.ToInt32(editedAppointment.AppointmentID);

                if (!e.IsNew)
                {
                    meeting = (from data in scheduleMeetings.Meeting_Tables
                                   where data.ID == appointmentID
                                   select data).First() as Meeting_Table;

                    meeting.Subject = editedAppointment.MappedSubject;
                    meeting.StartTime = editedAppointment.MappedStartTime.ToString();
                    meeting.EndTime = editedAppointment.MappedEndTime.ToString();
                    meeting.Color = editedAppointment.MappedColor.ToString();
                    meeting.IsAllDay = editedAppointment.MappedIsAllDay.ToString();
                    meeting.ID = appointmentID;
                }
                else
                {
                    meeting = new Meeting_Table();

                    meeting.Subject = editedAppointment.MappedSubject;
                    meeting.StartTime = editedAppointment.MappedStartTime.ToString();
                    meeting.EndTime = editedAppointment.MappedEndTime.ToString();
                    meeting.Color = editedAppointment.MappedColor.ToString();
                    meeting.IsAllDay = editedAppointment.MappedIsAllDay.ToString();
                    meeting.ID = appointmentID;

                    scheduleMeetings.Meeting_Tables.InsertOnSubmit(meeting);
                }               
                scheduleMeetings.SubmitChanges();
            }

            if (e.Action == EditorClosedAction.Delete)
            {
                var editedAppointment = (e.OriginalAppointment as ScheduleMeeting);
                var appointmentID = Convert.ToInt32(editedAppointment.AppointmentID);

                meeting = (from data in scheduleMeetings.Meeting_Tables
                           where data.ID == appointmentID
                           select data).First() as Meeting_Table;

                scheduleMeetings.Meeting_Tables.DeleteOnSubmit(meeting);
                scheduleMeetings.SubmitChanges();
            }

        }
    }

    

}
