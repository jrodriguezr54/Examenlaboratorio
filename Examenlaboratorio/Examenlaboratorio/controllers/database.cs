using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Examenlaboratorio.controllers
{
    public class database
    {
        readonly SQLiteAsyncConnection _connection;
        public database() { }

        public database(string dbpath) 
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            // Creacion de Base de Datos
            _connection.CreateTableAsync<models.contacto>().Wait();

        }

        //CRUD
        public Task<int> addcontacto(models.contacto contact)
        {
            if (contact.id == 0)
            {
                return _connection.InsertAsync(contact);
            }
            else
            {
                return _connection.UpdateAsync(contact);
            }
        }

        public Task<List<models.contacto>>obtenerlistacontacto()
        {
            return _connection.Table<models.contacto>().ToListAsync();
        }

        public Task<models.contacto> obtenercontacto(int pid)
        {
            return _connection.Table<models.contacto>().Where(i  => i.id == pid).FirstOrDefaultAsync();
        }

        public Task<int> deletecontacto(models.contacto contact)
        {
            return _connection.DeleteAsync(contact);
        }
    }
}
