﻿//by Fhiz
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using OpenMMO;

namespace OpenMMO {
	
	/// <summary>
	/// A basic, partial Template that represents the "Walk State".
	/// </summary>
	[CreateAssetMenu(fileName = "New WalkState", menuName = "OpenMMO - States/New WalkState", order = 999)]
	public partial class WalkStateTemplate : StateTemplate
	{
    
		/// <summary>
		/// Returns if the state is currently active.
		/// </summary>
		public override bool GetIsActive(EntityComponent entityComponent)
		{
			return entityComponent.movementComponent.GetIsMoving;
		}

	}

}