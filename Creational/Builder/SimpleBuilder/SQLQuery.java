import java.util.Objects;

public class SQLQuery {
    private final String query;

    private SQLQuery(String query) {
        this.query = query;
    }

    public void execute() {
        System.out.println("Executing the Query : " + query);
    }

    public static class SQLBuilder {
        private String select;
        private String from;
        private String where;
        private String orderBy;

        public SQLBuilder() {
        }

        public SQLBuilder withSelect(String select) {
            this.select = select;
            return this;
        }

        public SQLBuilder withFrom(String from) {
            this.from = from;
            return this;
        }

        public SQLBuilder withWhere(String where) {
            this.where = where;
            return this;
        }

        public SQLBuilder withOrderBy(String orderBy) {
            this.orderBy = orderBy;
            return this;
        }

        public SQLQuery build() {
            if (select == null || select.trim().isEmpty()) {
                throw new IllegalArgumentException("Select Clause is required");
            }
            if (from == null || from.trim().isEmpty()) {
                throw new IllegalArgumentException("From Clause is required");
            }

            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.append("SELECT ").append(select).append(" FROM ").append(from);

            if (where != null && !where.trim().isEmpty()) {
                queryBuilder.append(" Where ").append(where);
            }
            if (orderBy != null && !orderBy.trim().isEmpty()) {
                queryBuilder.append(" ORDERBY ").append(orderBy);
            }
            queryBuilder.append(";");

            return new SQLQuery(queryBuilder.toString());
        }
    }

    public static class SQLQueryArgumentBuilder {
        public static void main(String[] args) {
            SQLBuilder builder = new SQLBuilder();

            SQLQuery query = builder
                    .withSelect("*")
                    .withFrom(" users")
                    .withOrderBy("Desc") // Not strict with order providence
                    .withWhere("id = 20")
                    .build();
            query.execute();
        }
    }
}