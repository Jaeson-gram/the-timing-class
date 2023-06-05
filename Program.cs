using System.Diagnostics;

namespace DataStructuresAndAlgorithms
{
    public class TimingCode
    {
        static void Main(string[] args)
        {
            //create our array
            int[] myNumbers = new int[100000];

            //build the array with the method we made for it
            BuildArray(myNumbers);

            //create an instance of the timer class
            Timing timer = new Timing();

            //Test the code we want to test
            timer.startTime();
            DisplayNumbers(myNumbers);
            timer.stopTime();

            //display the result (in seconds, as specified in the Timer.result method)
            Console.WriteLine(); //one line space
            Console.WriteLine("\nTotal time for this: " + timer.Result().TotalSeconds + "s");
            Console.WriteLine("The UI did the delay");

            //THIS TOOK OVER 10seconds,
            //is it showing me a lot less than 1 second because the UI was what was updating, and it already did the job underground?
        }


        //method to automatically build an array of 10_000 numbers
        static void BuildArray(int[] array)
        {
            for (int i = 0; i <= 99999; i++)
            {
                //make the array in the index of i in each loop to be equal to the number developed in the given loop
                array[i] = i;
            }
        }

        //method to display the numbers in a given array
        static void DisplayNumbers(int[] array)
        {
            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }

    class Timing
    {
        //this class is used to test an array displayer. We'll use similar classes for algorithm testing


        TimeSpan startingtime;
        TimeSpan duration;

        public Timing()
        {
            this.startingtime = new TimeSpan(0);
            this.duration = new TimeSpan(0);
        }

        public void startTime()
        {
            //we call the Garbage collector so that our counter does not count extra time used by the Garbage Collector while we test a process
            //asking the Garbage collector to wait so we are sure there's no GCing while we run our tester
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //get the starting time of the code to test
            this.startingtime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }

        public void stopTime()
        {
            //get the stoping time of the code to test
            this.duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(this.startingtime);
        }

        //the method that returns the time our code spent running. 
        public TimeSpan Result()
        {
            return this.duration;
        }

    }
}