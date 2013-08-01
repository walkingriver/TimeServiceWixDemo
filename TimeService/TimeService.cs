using System.ServiceProcess;
using log4net;

namespace TimeService
{
    public partial class TimeService : ServiceBase
    {
        private TimeServiceAdapter adapter = new TimeServiceAdapter();
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TimeService));

        public TimeService()
        {
            Logger.Debug("TimeService initializing.");
            InitializeComponent();
            Logger.Debug("TimeService initialized.");
        }

        protected override void OnStart(string[] args)
        {
            Logger.Debug("TimeService starting.");
            adapter.Start();
            Logger.Debug("TimeService started.");
        }

        protected override void OnStop()
        {
            Logger.Debug("TimeService stopping.");
            adapter.Stop();
            Logger.Debug("TimeService stopped.");
        }
    }
}
