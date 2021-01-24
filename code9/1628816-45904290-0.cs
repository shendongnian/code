    <?xml version="1.0" encoding="utf-8" ?>
    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
    	<session-factory>
    		<property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
    		<property name="dialect">Netsis.Framework.Persister.Hibernate.Dialect.NMsSql2008Dialect, Netsis.Framework.Persister</property>
    		<property name="connection.driver_class">NHibernate.Driver.SqlClientDriver</property>
    		<property name="connection.connection_string">Data Source=localhost;Initial Catalog=CRM;Persist Security Info=True;User ID=user;Password=pass</property>
    		<property name="proxyfactory.factory_class">Netsis.Framework.Persister.Hibernate.Proxy.PropertyReaderProxyFactoryFactory,Netsis.Framework.Persister</property>
    		<property name="show_sql">True</property>
    		<property name="format_sql">True</property>
    		<property name="adonet.batch_size">30</property>  
    	</session-factory>
    </hibernate-configuration>
