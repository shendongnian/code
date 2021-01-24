    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using AutoMapper.Configuration.Conventions;
    using AutoMapper.Internal;
    
    namespace AutoMapper.Configuration.Conventions
    {
    	public class NameMatchMember : IChildMemberConfiguration
    	{
    		public bool MapDestinationPropertyToSource(ProfileMap options, TypeDetails sourceType, Type destType, Type destMemberType, string nameToSearch, LinkedList<MemberInfo> resolvers, IMemberConfiguration parent)
    		{
    			foreach (var memberInfo in sourceType.AllMembers)
    			{
    				if (!destType.Name.StartsWith(memberInfo.Name)) continue;
    				resolvers.AddLast(memberInfo);
    				var memberType = options.CreateTypeDetails(ReflectionHelper.GetMemberType(memberInfo));
    				if (parent.MapDestinationPropertyToSource(options, memberType, destType, destMemberType, nameToSearch, resolvers))
    					return true;
    				resolvers.RemoveLast();
    			}
    			return false;
    		}
    	}
    }
    
    namespace AutoMapper
    {
    	public static class Extensions
    	{
    		public static IMemberConfiguration AddNameMatchMemberConvention(this IProfileExpression target) =>
    			target.AddMemberConfiguration().AddNameMatchMemberConvention();
    
    		public static IMemberConfiguration AddNameMatchMemberConvention(this IMemberConfiguration target) =>
    			target.AddMember<NameMatchMember>();
    	}
    }
