    using UnityEngine;
    using System.Collections;
    
    public class Enemy:BaseFrite
    	{
    	public tk2dSpriteAnimator animMain;
    	public string usualAnimName;
    	
    	[System.NonSerialized] public Enemies boss;
    	
    	[Header("For this particular enemy class...")]
    	public float typeSpeedFactor;
    	public int typeStrength;
    	public int value;
    	
    	// could be changed at any time during existence of an item
    	
    	[System.NonSerialized] public FourLimits offscreen;	// must be set by our boss
    	
    	[System.NonSerialized] public int hitCount;			// that's ATOMIC through all integers
    	[System.NonSerialized] public int strength;			// just as atomic!
    	
    	[System.NonSerialized] public float beginsOnRight;
    	
    	private bool inPlay;	// ie, not still in runup
    	
    	void Awake()
    		{
    		boss = Gp.enemies;
    		}
    	
    	void Start()
    		{
    		}
    	
    	public void ChangeClipTo(string clipName)
    		{
    		if (animMain == null)
    			{
    			return;
    			}
    		
    		animMain.StopAndResetFrame();
    		animMain.Play(clipName);
    		}
    	
    	public virtual void ResetAndBegin()	// call from the boss, to kick-off sprite
    		{
    		hitCount = 0;
    		strength = typeStrength;
    		beginsOnRight = Gp.markers.HitsBeginOnRight();
    		Prepare();
    		Gp.run.runLevel.EnemyAvailable();
    		}
    	    	
    	protected virtual void Prepare()	// write it for this type of sprite
    		{
    		ChangeClipTo(bn);
    		// so, for the most basic enemy, you just do that
    		// for other enemy, that will be custom (example, swap damage sprites, etc)
    		}
    	
    	void OnTriggerEnter2D(Collider2D c)
    		{
    		
    		GameObject cgo = c.gameObject;
    		
    		// huge amount of code like this .......
    		if (cgo.layer == Grid.layerPeeps)	// we ran in to a "Peep"
    			{
    			Projectile p = c.GetComponent<Projectile>();
    			if (p == null)
    				{
    				Debug.Log("WOE!!! " +cgo.name);
    				return;
    				}
    			int damageNow = p.damage;
    			Hit(damageNow);
    			return;
    			}
    		
    		}
    	
    	public void _stepHit()
    		{
    		if ( transform.position.x > beginsOnRight ) return;
    		
    		++hitCount;
    		--strength;
    		ChangeAnimationsBasedOnHitCountIncrease();
    		// derived classes write that one.
    		
    		// todo, actually should the next passage only be after all the steps?
    		// is after all value is deducted? (just as with the _bashSound)...
    		
    		if (strength==0)	// enemy done for!
    			{
    			Gp.coins.CreateCoinBunch(value, transform.position);
    			FinalEffect();
    			
    			if ( Gp.skillsTest.on )
    				{
    				Gp.skillsTest.EnemyGottedInSkillsTest(gameObject);
    				boss.Done(this);
    				return;
    				}
    			
    			Grid.pops.GotEnemy(Gp.run.RunDistance);		// basically re meters/achvmts
    			EnemyDestroyedTypeSpecificStatsEtc();		// basically re achvments
    			Gp.run.runLevel.EnemyGotted();				// basically run/level stats
    			
    			boss.Done(this);							// basically removes it
    			}
    		}
    	
    	protected virtual void EnemyDestroyedTypeSpecificStatsEtc()
    		{
    		// you would use this in derives, to mark/etc class specifics
    		// most typically to alert achievements system if the enemy type needs to.
    		}
    	
    	private void _bashSound()
    		{
    		if (Gp.bil.ExplodishWeapon)
    			Grid.sfx.Play("Hit_Enemy_Explosive_A", "Hit_Enemy_Explosive_B");
    		else
    			Grid.sfx.Play("Hit_Enemy_Non_Explosive_A", "Hit_Enemy_Non_Explosive_B");
    		}
    	
    	public void Hit(int n)	// note that hitCount is atomic - hence strength, too
    		{
    		for (int i=1; i<=n; ++i) _stepHit();
    		
    		if (strength > 0) // bil hit the enemy, but enemy is still going.
    			_bashSound();
    		}
    	
    	protected virtual void ChangeAnimationsBasedOnHitCountIncrease()
    		{
    		// you may prefer to look at either "strength" or "hitCount"
    		}
    	
    	protected virtual void FinalEffect()
    		{
    		// so, for most derived it is this standard explosion...
    		Gp.explosions.MakeExplosion("explosionC", transform.position);
    		}
    	
    	public void Update()
    		{
    		if (!holdMovement) Movement();
    		
    		// note don't forget Translate is in Space.Self,
    		// so you are already heading transform.right - cool.
    		
    		if (offscreen.Outside(transform))
    			{
    			if (inPlay)
    				{
    				boss.Done(this);
    				return;
    				}
    			}
    		else
    			{
    			inPlay = true;
    			}
    		}
    	
    	protected virtual void Movement() // override for parabolas, etc etc
    		{
    		transform.Translate( -Time.deltaTime * mpsNow * typeSpeedFactor, 0f, 0f, Space.Self );
    		}
    	
    	}
