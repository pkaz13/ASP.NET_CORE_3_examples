namespace Paging_net_core_3_1
{
    public interface IPaginationMetadata
    {
        int CurrentPage { get; }
        int TotalPages { get; }
        int PageSize { get; }
        int TotalCount { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }
    }
}
