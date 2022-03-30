using Npgsql;

namespace user.Web.Repository
{
    internal class NpgSqlDataAdapter
    {
        private NpgsqlCommand cmd;

        public NpgSqlDataAdapter(NpgsqlCommand cmd)
        {
            this.cmd = cmd;
        }
    }
}