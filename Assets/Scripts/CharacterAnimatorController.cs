using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterAnimatorController
{
    public static class Triggers 
    { 
        public const string JumpTrigger = nameof(JumpTrigger);
        public const string RunTrigger = nameof(RunTrigger);
        public const string IdleTrigger = nameof(IdleTrigger);
    }

    public static class States
    {
        public const string IdleCharacter = nameof(IdleCharacter); 
        public const string RunCharacter = nameof(RunCharacter);
        public const string JumpCharacter = nameof(JumpCharacter);
    }
}