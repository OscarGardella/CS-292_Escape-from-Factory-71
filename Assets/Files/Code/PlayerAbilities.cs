using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public PowerBar player_power_bar;
    public PlayerHealth player_health_bar;
    public AbilityTracking abilityTracker;
    public RobotFreeAnim player_character;
    public Shield player_shield;

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Q)){
            ActivateAbility(abilityTracker.GetQAbility());
        }
        if (Input.GetKeyDown(KeyCode.E)){
            ActivateAbility(abilityTracker.GetEAbility());
        }
    }

    public void PassiveAbility(AbilityTracking.AbilityName ability){
        if(ability == AbilityTracking.AbilityName.Target){ //gain targeting laser ability
            //doubles fire rate
        } else if(ability == AbilityTracking.AbilityName.Heal){ //gain heal ability
            player_health_bar.UpgradeHealth(5);
        } else if(ability == AbilityTracking.AbilityName.Energy){ //gain energy ability
            player_power_bar.regen_rate = 2; //doubles power regen
        } else if(ability == AbilityTracking.AbilityName.Speed){ //gain energy ability
            //doubles move speed
        } 
    }

    void ActivateAbility(AbilityTracking.AbilityName ability){ 
        if(ability == AbilityTracking.AbilityName.Beam){ //use beam ability
            if(player_power_bar.ReducePower(7) == true){
                //beam method call
            }
        } else if(ability == AbilityTracking.AbilityName.Shield){ //use blackhole ability
            if(player_power_bar.ReducePower(6) == true){
                player_shield.ActivateShield(4.0f);
            }
        } else if(ability == AbilityTracking.AbilityName.Roll){ //use roll ability
            if(player_power_bar.ReducePower(4) == true){
                player_character.rollFor(2.0f);
            }
        }
    }
}