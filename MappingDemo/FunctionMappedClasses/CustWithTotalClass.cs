namespace MappingDemo
{
    public class CustWithTotalClass
    {
        public CustWithTotalClass(string name, int totalSpent)
        {
            Name = name;
            TotalSpent = totalSpent;
        }
        public string Name { get; private set; }
        public int TotalSpent { get; private set; }
    }
}
