namespace Paging_net_core_3_1
{
    public interface IQueryStringParameters
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}