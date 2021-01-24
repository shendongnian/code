    <hibernate-mapping xmlns="urn:nhibernate-mapping-2.2">
      <class xmlns="urn:nhibernate-mapping-2.2" schema="dbo" name="MyCompany.MyTechnology.Prototypes.CompositeAppPOC.Data.NHibernateSetup.Domain.EmployeeToJobTitleMatchLinkNHEntity, MyCompany.MyTechnology.Prototypes.CompositeAppPOC.Data.NHibernateSetup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" table="EmployeeToJobTitleMatchLink">
        <id name="LinkSurrogateUUID" type="System.Nullable`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
          <column name="LinkSurrogateUUID" />
          <generator class="guid.comb" />
        </id>
        <property name="PriorityRank" type="System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
          <column name="PriorityRank" />
        </property>
        <property name="JobStartedOnDate" type="System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
          <column name="JobStartedOnDate" />
        </property>
        <many-to-one class="MyCompany.MyTechnology.Prototypes.CompositeAppPOC.Data.NHibernateSetup.Domain.EmployeeNHEntity, MyCompany.MyTechnology.Prototypes.CompositeAppPOC.Data.NHibernateSetup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" name="TheEmployee">
          <column name="TheEmployeeUUID" index="IX_ETJTMLM_TheEmployeeUUID_And_TheJobTitleUUID" not-null="true" />
        </many-to-one>
        <many-to-one class="MyCompany.MyTechnology.Prototypes.CompositeAppPOC.Data.NHibernateSetup.Domain.JobTitleNHEntity, MyCompany.MyTechnology.Prototypes.CompositeAppPOC.Data.NHibernateSetup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" name="TheJobTitle">
          <column name="TheJobTitleUUID" index="IX_ETJTMLM_TheEmployeeUUID_And_TheJobTitleUUID" not-null="true" />
        </many-to-one>
      </class>
    </hibernate-mapping>
