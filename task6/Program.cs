using System;

namespace task6{
    delegate void ThresholdReachedHandler(int threshold, int currentCount);

    class Counter{
        private int _threshold = 0;
        private int _count = 0;

        public event ThresholdReachedHandler ThresholdReached;

        public Counter(int threshold){
            _threshold = threshold;
        }

        public void Increment(){
            _count++;
            Console.WriteLine($"  Counter → {_count}");

            if(_count == _threshold && ThresholdReached != null){
                ThresholdReached(_threshold,_count);
            }
        }

        public int Count => _count;
        public int Threshold => _threshold;

        public void RaiseThresholdReached(){
            ThresholdReached?.Invoke(_threshold, _count);
        }
    }

    class AlertSystem{
        public void SendAlert(int threshold, int currentCount){
            Console.WriteLine($"\n[AlertSystem] Threshold {threshold} hit! " +
                              $"Sending alert notification...");
        }
    }

    class Logger{
        public void LogEvent(int threshold, int currentCount){
            string logEntry = $"THRESHOLD REACHED — " + $"Count: {currentCount}, Limit: {threshold}";
            Console.WriteLine($"[Logger] : {logEntry}");
        }
    }

    class Dashboard{
        public void updateDisplay(int threshold, int currentCount){
            Console.WriteLine($"[Dashboard] Updating UI — " + $"{currentCount}/{threshold} increments completed.");
        }
    }

    class Program{
        static void Main(string[] args){
            Console.WriteLine("Enter the counter threshold:");
            int threshold = Convert.ToInt32(Console.ReadLine().Trim());

            Counter counter = new Counter(threshold);

            AlertSystem alertSystem = new AlertSystem();
            Logger logger = new Logger();
            Dashboard dashboard = new Dashboard();

            counter.ThresholdReached += alertSystem.SendAlert;
            counter.ThresholdReached += logger.LogEvent;
            counter.ThresholdReached += dashboard.updateDisplay;

            Console.WriteLine($"\nIncrementing counter (threshold = {threshold})\n");

            for(int i=0;i<threshold;i++){
                counter.Increment();
            }

            Console.WriteLine("\nAll handlers executed. Counter stopped.");

            Console.WriteLine("\nUnsubscribing Logger and re-triggering manually\n");
            counter.ThresholdReached -= logger.LogEvent;
            Console.WriteLine("Re-raising event after unsubscribe:\n");
            counter.RaiseThresholdReached();

        }
    }
}