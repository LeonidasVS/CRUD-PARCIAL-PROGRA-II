La base de datos utiliza es Northwind, teniendo como referencia la tabla Suppliers. 
La tabla tiene una restriccion que la llave primaria es llave foreana en la
tabla Products, entonces para realizar el CRUD completo se tuvo que deshabilitar
la restriccion con el siguiente comando:
ALTER TABLE nombre_tabla  
NOCHECK CONSTRAINT nombre_restriccion;
