namespace Paging_net_core_3_1
{
    public abstract class QueryStringParameters : IQueryStringParameters
    {
        public int MaxPageSize { get; } = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
