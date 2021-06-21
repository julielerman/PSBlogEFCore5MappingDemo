namespace MappingDemo
{
    public class CustWithTotal
    {
        public CustWithTotal(string name, int totalSpent)
        {
            Name = name;
            TotalSpent = totalSpent;
        }
        public string Name { get; set; }
        public int TotalSpent { get; set; }
    }
}