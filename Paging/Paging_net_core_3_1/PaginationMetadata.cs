using System;

namespace Paging_net_core_3_1
{
    public class PaginationMetadata : IPaginationMetadata
    {
        public int CurrentPage { get; }

        public int TotalPages { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public bool HasPrevious { get; }

        public bool HasNext { get; }

        public PaginationMetadata(int totalCount, int pageNumber, int pageSize)
        {
            TotalCount = totalCount;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            HasPrevious = CurrentPage > 1;
            HasNext = CurrentPage < TotalPages;
        }
    }
}
