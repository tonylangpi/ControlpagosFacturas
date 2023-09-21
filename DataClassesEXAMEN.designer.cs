﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlPagosFacturas
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="UMGEXAMEN")]
	public partial class DataClassesEXAMENDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertUsuarios(Usuarios instance);
    partial void UpdateUsuarios(Usuarios instance);
    partial void DeleteUsuarios(Usuarios instance);
    partial void Insertclientes(clientes instance);
    partial void Updateclientes(clientes instance);
    partial void Deleteclientes(clientes instance);
    partial void InsertMES(MES instance);
    partial void UpdateMES(MES instance);
    partial void DeleteMES(MES instance);
    partial void InsertVenta(Venta instance);
    partial void UpdateVenta(Venta instance);
    partial void DeleteVenta(Venta instance);
    #endregion
		
		public DataClassesEXAMENDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["UMGEXAMENConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesEXAMENDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesEXAMENDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesEXAMENDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesEXAMENDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Usuarios> Usuarios
		{
			get
			{
				return this.GetTable<Usuarios>();
			}
		}
		
		public System.Data.Linq.Table<clientes> clientes
		{
			get
			{
				return this.GetTable<clientes>();
			}
		}
		
		public System.Data.Linq.Table<MES> MES
		{
			get
			{
				return this.GetTable<MES>();
			}
		}
		
		public System.Data.Linq.Table<Venta> Venta
		{
			get
			{
				return this.GetTable<Venta>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuarios")]
	public partial class Usuarios : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _correo;
		
		private string _clave;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OncorreoChanging(string value);
    partial void OncorreoChanged();
    partial void OnclaveChanging(string value);
    partial void OnclaveChanged();
    #endregion
		
		public Usuarios()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_correo", DbType="VarChar(100)")]
		public string correo
		{
			get
			{
				return this._correo;
			}
			set
			{
				if ((this._correo != value))
				{
					this.OncorreoChanging(value);
					this.SendPropertyChanging();
					this._correo = value;
					this.SendPropertyChanged("correo");
					this.OncorreoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_clave", DbType="VarChar(100)")]
		public string clave
		{
			get
			{
				return this._clave;
			}
			set
			{
				if ((this._clave != value))
				{
					this.OnclaveChanging(value);
					this.SendPropertyChanging();
					this._clave = value;
					this.SendPropertyChanged("clave");
					this.OnclaveChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.clientes")]
	public partial class clientes : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _Dpi;
		
		private string _nombres;
		
		private string _direccion;
		
		private string _telefono;
		
		private System.Nullable<decimal> _limiteCredito;
		
		private EntitySet<Venta> _Venta;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnDpiChanging(string value);
    partial void OnDpiChanged();
    partial void OnnombresChanging(string value);
    partial void OnnombresChanged();
    partial void OndireccionChanging(string value);
    partial void OndireccionChanged();
    partial void OntelefonoChanging(string value);
    partial void OntelefonoChanged();
    partial void OnlimiteCreditoChanging(System.Nullable<decimal> value);
    partial void OnlimiteCreditoChanged();
    #endregion
		
		public clientes()
		{
			this._Venta = new EntitySet<Venta>(new Action<Venta>(this.attach_Venta), new Action<Venta>(this.detach_Venta));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dpi", DbType="VarChar(100)")]
		public string Dpi
		{
			get
			{
				return this._Dpi;
			}
			set
			{
				if ((this._Dpi != value))
				{
					this.OnDpiChanging(value);
					this.SendPropertyChanging();
					this._Dpi = value;
					this.SendPropertyChanged("Dpi");
					this.OnDpiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombres", DbType="VarChar(150)")]
		public string nombres
		{
			get
			{
				return this._nombres;
			}
			set
			{
				if ((this._nombres != value))
				{
					this.OnnombresChanging(value);
					this.SendPropertyChanging();
					this._nombres = value;
					this.SendPropertyChanged("nombres");
					this.OnnombresChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_direccion", DbType="VarChar(250)")]
		public string direccion
		{
			get
			{
				return this._direccion;
			}
			set
			{
				if ((this._direccion != value))
				{
					this.OndireccionChanging(value);
					this.SendPropertyChanging();
					this._direccion = value;
					this.SendPropertyChanged("direccion");
					this.OndireccionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_telefono", DbType="VarChar(30)")]
		public string telefono
		{
			get
			{
				return this._telefono;
			}
			set
			{
				if ((this._telefono != value))
				{
					this.OntelefonoChanging(value);
					this.SendPropertyChanging();
					this._telefono = value;
					this.SendPropertyChanged("telefono");
					this.OntelefonoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_limiteCredito", DbType="Decimal(12,2)")]
		public System.Nullable<decimal> limiteCredito
		{
			get
			{
				return this._limiteCredito;
			}
			set
			{
				if ((this._limiteCredito != value))
				{
					this.OnlimiteCreditoChanging(value);
					this.SendPropertyChanging();
					this._limiteCredito = value;
					this.SendPropertyChanged("limiteCredito");
					this.OnlimiteCreditoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="clientes_Venta", Storage="_Venta", ThisKey="id", OtherKey="cliente")]
		public EntitySet<Venta> Venta
		{
			get
			{
				return this._Venta;
			}
			set
			{
				this._Venta.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Venta(Venta entity)
		{
			this.SendPropertyChanging();
			entity.clientes = this;
		}
		
		private void detach_Venta(Venta entity)
		{
			this.SendPropertyChanging();
			entity.clientes = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MES")]
	public partial class MES : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _descripcion;
		
		private EntitySet<Venta> _Venta;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OndescripcionChanging(string value);
    partial void OndescripcionChanged();
    #endregion
		
		public MES()
		{
			this._Venta = new EntitySet<Venta>(new Action<Venta>(this.attach_Venta), new Action<Venta>(this.detach_Venta));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descripcion", DbType="VarChar(100)")]
		public string descripcion
		{
			get
			{
				return this._descripcion;
			}
			set
			{
				if ((this._descripcion != value))
				{
					this.OndescripcionChanging(value);
					this.SendPropertyChanging();
					this._descripcion = value;
					this.SendPropertyChanged("descripcion");
					this.OndescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="MES_Venta", Storage="_Venta", ThisKey="id", OtherKey="Mes")]
		public EntitySet<Venta> Venta
		{
			get
			{
				return this._Venta;
			}
			set
			{
				this._Venta.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Venta(Venta entity)
		{
			this.SendPropertyChanging();
			entity.MES1 = this;
		}
		
		private void detach_Venta(Venta entity)
		{
			this.SendPropertyChanging();
			entity.MES1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Venta")]
	public partial class Venta : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _SerieFactura;
		
		private System.Nullable<System.DateTime> _Fecha;
		
		private System.Nullable<int> _Mes;
		
		private System.Nullable<decimal> _monto;
		
		private string _TipoFactura;
		
		private string _EstadoFactura;
		
		private System.Nullable<int> _cliente;
		
		private EntityRef<clientes> _clientes;
		
		private EntityRef<MES> _MES1;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnSerieFacturaChanging(string value);
    partial void OnSerieFacturaChanged();
    partial void OnFechaChanging(System.Nullable<System.DateTime> value);
    partial void OnFechaChanged();
    partial void OnMesChanging(System.Nullable<int> value);
    partial void OnMesChanged();
    partial void OnmontoChanging(System.Nullable<decimal> value);
    partial void OnmontoChanged();
    partial void OnTipoFacturaChanging(string value);
    partial void OnTipoFacturaChanged();
    partial void OnEstadoFacturaChanging(string value);
    partial void OnEstadoFacturaChanged();
    partial void OnclienteChanging(System.Nullable<int> value);
    partial void OnclienteChanged();
    #endregion
		
		public Venta()
		{
			this._clientes = default(EntityRef<clientes>);
			this._MES1 = default(EntityRef<MES>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SerieFactura", DbType="VarChar(100)")]
		public string SerieFactura
		{
			get
			{
				return this._SerieFactura;
			}
			set
			{
				if ((this._SerieFactura != value))
				{
					this.OnSerieFacturaChanging(value);
					this.SendPropertyChanging();
					this._SerieFactura = value;
					this.SendPropertyChanged("SerieFactura");
					this.OnSerieFacturaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="Date")]
		public System.Nullable<System.DateTime> Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this.OnFechaChanging(value);
					this.SendPropertyChanging();
					this._Fecha = value;
					this.SendPropertyChanged("Fecha");
					this.OnFechaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Mes", DbType="Int")]
		public System.Nullable<int> Mes
		{
			get
			{
				return this._Mes;
			}
			set
			{
				if ((this._Mes != value))
				{
					if (this._MES1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMesChanging(value);
					this.SendPropertyChanging();
					this._Mes = value;
					this.SendPropertyChanged("Mes");
					this.OnMesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_monto", DbType="Decimal(12,2)")]
		public System.Nullable<decimal> monto
		{
			get
			{
				return this._monto;
			}
			set
			{
				if ((this._monto != value))
				{
					this.OnmontoChanging(value);
					this.SendPropertyChanging();
					this._monto = value;
					this.SendPropertyChanged("monto");
					this.OnmontoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TipoFactura", DbType="VarChar(100)")]
		public string TipoFactura
		{
			get
			{
				return this._TipoFactura;
			}
			set
			{
				if ((this._TipoFactura != value))
				{
					this.OnTipoFacturaChanging(value);
					this.SendPropertyChanging();
					this._TipoFactura = value;
					this.SendPropertyChanged("TipoFactura");
					this.OnTipoFacturaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EstadoFactura", DbType="VarChar(100)")]
		public string EstadoFactura
		{
			get
			{
				return this._EstadoFactura;
			}
			set
			{
				if ((this._EstadoFactura != value))
				{
					this.OnEstadoFacturaChanging(value);
					this.SendPropertyChanging();
					this._EstadoFactura = value;
					this.SendPropertyChanged("EstadoFactura");
					this.OnEstadoFacturaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cliente", DbType="Int")]
		public System.Nullable<int> cliente
		{
			get
			{
				return this._cliente;
			}
			set
			{
				if ((this._cliente != value))
				{
					if (this._clientes.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnclienteChanging(value);
					this.SendPropertyChanging();
					this._cliente = value;
					this.SendPropertyChanged("cliente");
					this.OnclienteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="clientes_Venta", Storage="_clientes", ThisKey="cliente", OtherKey="id", IsForeignKey=true)]
		public clientes clientes
		{
			get
			{
				return this._clientes.Entity;
			}
			set
			{
				clientes previousValue = this._clientes.Entity;
				if (((previousValue != value) 
							|| (this._clientes.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._clientes.Entity = null;
						previousValue.Venta.Remove(this);
					}
					this._clientes.Entity = value;
					if ((value != null))
					{
						value.Venta.Add(this);
						this._cliente = value.id;
					}
					else
					{
						this._cliente = default(Nullable<int>);
					}
					this.SendPropertyChanged("clientes");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="MES_Venta", Storage="_MES1", ThisKey="Mes", OtherKey="id", IsForeignKey=true)]
		public MES MES1
		{
			get
			{
				return this._MES1.Entity;
			}
			set
			{
				MES previousValue = this._MES1.Entity;
				if (((previousValue != value) 
							|| (this._MES1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._MES1.Entity = null;
						previousValue.Venta.Remove(this);
					}
					this._MES1.Entity = value;
					if ((value != null))
					{
						value.Venta.Add(this);
						this._Mes = value.id;
					}
					else
					{
						this._Mes = default(Nullable<int>);
					}
					this.SendPropertyChanged("MES1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
