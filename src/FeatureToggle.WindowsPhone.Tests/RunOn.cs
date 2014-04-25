﻿using System;
using System.Threading;
using System.Windows;

namespace FeatureToggle.WindowsPhone.Tests
{   
    public static class RunOn
    {
        public static void Dispatcher(Action a, int timeOut = 5000)
        {
            var waitHandle = new AutoResetEvent(false);

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                try
                {
                    a.Invoke();
                }
                catch (Exception ex)
                {
                    
                }
                finally
                {
                    waitHandle.Set();
                }                              
            });

            waitHandle.WaitOne(timeOut);
        }        
    }

}
