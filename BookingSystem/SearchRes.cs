namespace BookingSystem
{
    public class SearchRes
    {
        public Option[] options { get; set; }

        public SearchRes(Option[] options)
        {
            this.options = options;
        }
    }
}
