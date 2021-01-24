    <destinationPolicy>
      <policyMap>
        <policyEntries>
          <policyEntry topic=">" >
            <subscriptionRecoveryPolicy>
              <timedSubscriptionRecoveryPolicy recoverDuration="10000" />
              <fixedCountSubscriptionRecoveryPolicy maximumSize="10000" />
            </subscriptionRecoveryPolicy>
          </policyEntry>
        </policyEntries>
      </policyMap>
    </destinationPolicy>
