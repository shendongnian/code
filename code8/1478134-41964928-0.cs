    <profiles>
      <profile>
        <id>sonarsource-repo</id>
        <activation>
          <property>
            <name>!skip-sonarsource-repo</name>
          </property>
        </activation>
        <repositories>
          <repository>
            <id>sonarsource</id>
            <name>SonarSource Central Repository</name>
            <url>https://repox.sonarsource.com/sonarsource</url>
            <releases>
              <enabled>true</enabled>
              <updatePolicy>interval:60</updatePolicy>
              <checksumPolicy>fail</checksumPolicy>
            </releases>
            <snapshots>
              <enabled>false</enabled>
              <updatePolicy>never</updatePolicy>
            </snapshots>
          </repository>
        </repositories>
        <pluginRepositories>
          <pluginRepository>
            <id>sonarsource</id>
            <name>SonarSource Central Repository</name>
            <url>https://repox.sonarsource.com/sonarsource</url>
            <releases>
              <enabled>true</enabled>
              <!-- no need to always check if new versions are available when
              executing a maven plugin without specifying the version -->
              <updatePolicy>interval:60</updatePolicy>
              <checksumPolicy>fail</checksumPolicy>
            </releases>
            <snapshots>
              <enabled>false</enabled>
              <updatePolicy>never</updatePolicy>
            </snapshots>
          </pluginRepository>
        </pluginRepositories>
      </profile>
    </profiles>
