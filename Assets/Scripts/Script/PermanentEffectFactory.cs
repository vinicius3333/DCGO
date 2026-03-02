using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Class for given effects for Permanents, applying to the entire stack even if any specific card is removed from it
/// </summary>
public partial class PermanentEffectFactory
{
    #region Cannot change Attack Target Effect
    public static CanNotSwitchAttackTargetClass CanNotSwitchAttackTargetEffect(Permanent targetPermanent)
    {
        CanNotSwitchAttackTargetClass canNotSwitchAttackTargetClass = new CanNotSwitchAttackTargetClass();
        canNotSwitchAttackTargetClass.SetUpICardEffect("This Digimon's attack target can't be switched.", CanUseCondition, targetPermanent.TopCard);
        canNotSwitchAttackTargetClass.SetUpCanNotSwitchAttackTargetClass(PermanentCondition: PermanentCondition);
        return canNotSwitchAttackTargetClass;

        bool CanUseCondition(Hashtable hashtable)
        {
            return CardEffectCommons.IsPermanentExistsOnBattleArea(targetPermanent) &&
                    CardEffectCommons.IsOwnerTurn(targetPermanent.TopCard);
        }

        bool PermanentCondition(Permanent permanent)
        {
            return permanent != null && permanent.TopCard && permanent == targetPermanent;
        }
    }
    #endregion
}