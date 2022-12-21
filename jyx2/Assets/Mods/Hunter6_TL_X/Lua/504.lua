if H6_isStudy==nil then
	local runtime = CS.Jyx2.GameRuntimeData.Instance
	if runtime.Player.Attack<30 then
		--避免多次增加，进入游戏只在一开始增加主角能力
		--local role = CS.Jyx2.RoleInstance
		--print(role)
		--print("attack="..role.Attack)

		AddSpeed(0,22)
		AddHp(0,1500)
		AddMp(0,190)--增加内力
		AddQuanzhang(0,60)--增加拳掌
		AddAttack(0,600)--增加攻击

		AddItem(54,1)--铁掌拳
		AddItem(55,1)--七伤拳
		AddItem(62,1)	
		AddItem(107,1)
	end
	H6_isStudy = true
end
Talk(0,"这是龙门客栈")

if AskBattle() then
	if TryBattle(140) then
		
	end
	do return end;
else
	Talk(0,"还是不打了")
	do return end;	
end