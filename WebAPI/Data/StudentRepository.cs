using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new MySqlConnection(_connectionString); } }
        public StudentRepository()
        {
            _connectionString = "server=localhost;database=studentinfo;user=root; password=dilan123;port=3306";
        }
        public async Task AddAsync(Student student)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"INSERT INTO `student`(`StId`, `Tckn`, `FirstName`, `LastName`, `Birthday`, `City`, `Gender`) 
                VALUES(@StId,
                                @Tckn,
                                @FirstName,
                                @LastName,
                                @Birthday,
                                @City,
                                @Gender)";

                await dbConnection.ExecuteAsync(query, student);
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT `StId`, `Tckn`, `FirstName`, `LastName`, `Birthday`, `City`, `Gender` FROM `student` WHERE 1";

                var student = await dbConnection.QueryAsync<Student>(query);

                return student;
            }
        }

        public async Task<Student> GetAsync(long id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query= @"SELECT `StId`, `Tckn`, `FirstName`, `LastName`, `Birthday`, `City`, `Gender` FROM `student` WHERE `StId`=@StId ";
                var student = await dbConnection.QueryFirstOrDefaultAsync<Student>(query, new { @StId = id });
           
                return student;
            }
        }
    }
}
