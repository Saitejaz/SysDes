using System;

public class SQLQuery
{
    private string Query { get; }
    private SQLQuery(string query)
    {
        Query = query;
    }

    public void Execute()
    {
        Console.WriteLine($"Executing the Query : {Query}");
    }


    public class SQLBuilder
    {
        private string? _select;
        private string? _from;
        private string? _where;
        private string? _orderBy;
        // SQLQuery query = new SQLQuery("");
        public SQLBuilder()
        {

        }
        public SQLBuilder withSelect(string select)
        {
            _select = select;
            return this;
        }
        public SQLBuilder withFrom(string from)
        {
            _from = from;
            return this;
        }
        public SQLBuilder withWhere(string where)
        {
            _where = where;
            return this;
        }
        public SQLBuilder withOrderBy(string orderBy)
        {
            _orderBy = orderBy;
            return this;
        }

        public SQLQuery Build()
        {

            if (string.IsNullOrWhiteSpace(_select))
            {
                throw new ArgumentException("Select Clause is required");
            }
            if (string.IsNullOrWhiteSpace(_from))
            {
                throw new ArgumentException("From Clause is required");
            }

            var query = $"SELECT {_select} FROM {_from}";

            if (!string.IsNullOrWhiteSpace(_where))
            {
                query += $" Where {_where}";
            }
            if (!string.IsNullOrWhiteSpace(_orderBy))
            {
                query += $" ORDER BY {_orderBy}";
            }
            query += ";";
            return new SQLQuery(query);
        }
    }

    public class SQLQueryDirector
    {
        public SQLQuery GetAllUsers(SQLQuery.SQLBuilder builder)
        {
            return builder
                   .withSelect("*")
                   .withFrom("Users")
                   .Build();
        }

        public SQLQuery GetAllUserById(SQLQuery.SQLBuilder builder, int id)
        {
            return builder
                   .withSelect("*")
                   .withFrom("Users")
                   .withWhere($"id = {id}")
                   .Build();
        }
    }

    public class SQLQueryArgumentBuilder
    {
        public static void Main()
        {
            var builder = new SQLBuilder();

            // We Provide chaining
            var query = builder
                          .withSelect("*")
                          .withFrom("users")
                          .withOrderBy("Desc") // Not strict with order providence
                          .withWhere("id = 20")
                        .Build();
            query.Execute();

            //With Director
            var director = new SQLQueryDirector();
            var query2 = director.GetAllUsers(new SQLQuery.SQLBuilder());
            query2.Execute();


        }
    }
}