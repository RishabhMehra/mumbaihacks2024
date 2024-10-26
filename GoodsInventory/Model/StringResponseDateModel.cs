namespace GoodsInventory.Model
{
    public class StringResponseDateModel
    {
        public StringResponseDateModel() 
        {
            computed_date = new ComputedDate();
        }    
        public ComputedDate computed_date { get; set; }
        public int current_day { get; set; }
        public int current_hour { get; set; }
        public int current_month { get; set; }
        public string detected_temporal_word { get; set; }
    }
    public class ComputedDate
    {
        public int day { get; set; }
        public int hour { get; set; }
        public int month { get; set; }
    }
}