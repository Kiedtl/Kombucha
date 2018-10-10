using System;
using Sentry;


namespace Kombucha.Error
{
    class SentryErrorHandle
    {
        public void ReportErrorToSentry(Exception err, string func, bool InformUser)
        {
            using (SentrySdk.Init("https://c9f149c50f4b40b98191e621f79e3669@sentry.io/1294828"))
            {
                SentrySdk.CaptureException(err, func);
            }

            if (InformUser)
            {
                Kombucha.Print.PrintOut(Kombucha.Print.Level.ERROR, "Kombucha encountered an internal error: " + err.Message());
            }
        }

        public void ReportErrorToSentry(Exception err, string func)
        {
            using (SentrySdk.Init("https://c9f149c50f4b40b98191e621f79e3669@sentry.io/1294828"))
            {
                SentrySdk.CaptureException(err, func);
                Kombucha.Print.PrintOut(Kombucha.Print.Level.ERROR, "Kombucha encountered an internal error: " + err.Message());

            }
        }

        public void ReportErrorToSentry(Exception err)
        {
            using (SentrySdk.Init("https://c9f149c50f4b40b98191e621f79e3669@sentry.io/1294828"))
            {
                SentrySdk.CaptureException(err);
                Kombucha.Print.PrintOut(Kombucha.Print.Level.ERROR, "Kombucha encountered an internal error: " + err.Message());

            }
        }
    }
}
