using System;
using System.Diagnostics;

// define namespace
namespace WriteToAppEventLog
{
    // define classs
    class AppEvent
    {
        static void Main(string[] args)
        {
            // This entry is shown in the column "Source" in the local eventviewer. 
            // To keep it simple I am reusing "Application Error" because it is an already registered source on any Windows OS. 
            string _source = "Application Error";
            // The log entry is written to the Application log
            // Please keep the local Application log and do *NOT* use the Security log, because then you would have to run this application with Administrator permissions. 
            string _log = "Application";
            // This is the text written to the Application event log.
            string _event = "Possible Ransomware Event";
       
            // The next line execs the command to write to the Application log and defines the type of "Warning" and the event ID 765. 
            // If there is anything you really want to change in this code, then enter your own unique event ID to make the detection in your SIEM easier.
            // Usually filtering based on the source string "Ransomware Vaccine" in combination with the event ID 765 should be enough to make this entry unique in your environment
            EventLog.WriteEntry(_source, _event, EventLogEntryType.Warning, 765);
        }
    }
}