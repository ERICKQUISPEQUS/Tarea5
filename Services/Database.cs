﻿using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using MiAppCrud.Models;

public class Database
{
    private SQLiteAsyncConnection _database;

    public Database(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        
        _database.CreateTableAsync<Producto>().Wait();
        _database.CreateTableAsync<Categoria>().Wait(); 
    }


    public Task<List<Producto>> GetAllProductosAsync()
    {
        return _database.Table<Producto>().ToListAsync();
    }

    public Task<Producto> GetProductoAsync(int id)
    {
        return _database.Table<Producto>().FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<int> SaveProductoAsync(Producto producto)
    {
        if (producto.Id != 0)
            return _database.UpdateAsync(producto);
        else
            return _database.InsertAsync(producto);
    }

    public Task<int> DeleteProductoAsync(int id)
    {
        return _database.DeleteAsync<Producto>(id);
    }

    public Task<List<Categoria>> GetAllCategoriasAsync()
    {
        return _database.Table<Categoria>().ToListAsync();
    }

    public Task<Categoria> GetCategoriaAsync(int id)
    {
        return _database.Table<Categoria>().FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<int> SaveCategoriaAsync(Categoria categoria)
    {
        if (categoria.Id != 0)
            return _database.UpdateAsync(categoria);
        else
            return _database.InsertAsync(categoria);
    }

    public Task<int> DeleteCategoriaAsync(int id)
    {
        return _database.DeleteAsync<Categoria>(id);
    }
    public Task<List<Proveedor>> GetAllProveedoresAsync() => _database.Table<Proveedor>().ToListAsync();
    public Task<int> SaveProveedorAsync(Proveedor proveedor) => proveedor.Id != 0 ? _database.UpdateAsync(proveedor) : _database.InsertAsync(proveedor);
    public Task<int> DeleteProveedorAsync(int id) => _database.DeleteAsync<Proveedor>(id);

    // Métodos para órdenes
    public Task<List<Orden>> GetAllOrdenesAsync() => _database.Table<Orden>().ToListAsync();
    public Task<int> SaveOrdenAsync(Orden orden) => orden.Id != 0 ? _database.UpdateAsync(orden) : _database.InsertAsync(orden);
    public Task<int> DeleteOrdenAsync(int id) => _database.DeleteAsync<Orden>(id);


}
