namespace AwesomePerformance
{
    public class ItemPool
    {      
        public int Number { get; set; }
        public int Repetitions { get; set; }

        public ItemPool(int number, int repetitions)
        {
            this.Number = number;
            this.Repetitions = repetitions;
        }
    }
}
