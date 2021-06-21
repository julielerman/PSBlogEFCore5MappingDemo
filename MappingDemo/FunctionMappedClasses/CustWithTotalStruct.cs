namespace MappingDemo
{
    public struct CustWithTotalStruct
    {
        public CustWithTotalStruct(string name, int total)
        {
            Name = name;
            TotalSpent = total;
        }
        public string Name { get; }
        public int TotalSpent { get; }
    }
}