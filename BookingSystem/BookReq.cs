namespace BookingSystem
{
    public class BookReq
    {
        public int OptionCode { get; set; }
        public SearchReq SearchReq { get; set; }

        public BookReq(int optionCode, SearchReq searchReq)
        {
            OptionCode = optionCode;
            SearchReq = searchReq;
        }
    }
}
