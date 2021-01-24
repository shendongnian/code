    cfg.xml
    
    <?xml version="1.0" encoding="utf-8" ?>
    <hibernate-configuration  xmlns="urn:nhibernate-configuration-2.2"  >
      <session-factory>
        <property name="connection.driver_class">NHibernate.Driver.SQLite20Driver</property>
        <property name="connection.connection_string">
          Data Source=SicakSatisDB.db;Version=3;
        </property>
        <property name="dialect">NHibernate.Dialect.SQLiteDialect</property>
        <property name="proxyfactory.factory_class">NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle</property>
      </session-factory>
    </hibernate-configuration>
