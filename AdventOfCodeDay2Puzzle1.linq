<Query Kind="Program">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static async Task Main()
{

	//var multiLineInput = await GetPuzzleInputAsync();  //let's not hammer the poor hosting site
	var multiLineInput = await GetPuzzleInputOffline();
	//multiLineInput.Dump();
	var inputList = multiLineInput.Split(new string[]{ "\n" }, StringSplitOptions.RemoveEmptyEntries);
	//inputList.Count().Dump("Count");

	var validCount = 0;
	foreach(var input in inputList) {
		//input.Dump();
		var entry = input.Split(' ');
		//entry.Dump();
		const int count = 0;
		const int letter = 1;
		const int password = 2;
		var range = entry[count].Split('-');
		//range.Dump("Range");
		var rangeFrom = int.Parse(range[0]);
		var rangeTo = int.Parse(range[1]);
		var charToFind = entry[letter][0];
		//charToFind.Dump("character to find");
		//entry[password].Dump("Password");
		var matchCount = entry[password].Count(f => f == charToFind);
		//matchCount.Dump("Match Count");
		if(matchCount>=rangeFrom && matchCount<=rangeTo) 
		{
			validCount++;
		}
		//break;
	}
	validCount.Dump("validCount");
}

// You can define other methods, fields, classes and namespaces here
public static async Task<string> GetPuzzleInputAsync()
{
	// Initialization.  
	List<string> puzzleInput = new List<string>();
	const string sessionCookie = "_ga=GA1.2.918020773.1606803859; _gid=GA1.2.1131951502.1606803859; ru=53616c7465645f5f40ba35026abee564eec17100e741144c4fd294b2d652f987e0e66a05f3d536ffbb893d36ebc954d3; session=53616c7465645f5f30362387c56a05404f21b59f522335f1fbf01d028a480a5a68be90f0f00b4cd064e548429d869b7b; _gat=1";
	// HTTP GET.  
	string result = string.Empty;
	using (var client = new HttpClient())
	{
		// Setting Base address.  
		client.BaseAddress = new Uri("https://adventofcode.com/");

		// Setting content type.  
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
		client.DefaultRequestHeaders.Add("Cookie", sessionCookie);

		// Initialization.  
		HttpResponseMessage response = new HttpResponseMessage();

		// HTTP GET  
		response = await client.GetAsync("2020/day/2/input");

		// Verification  
		if (response.IsSuccessStatusCode)
		{
			// Reading Response.  
			
			result = await response.Content.ReadAsStringAsync();
			
		}
	}
	return result;
}

public static async Task<string> GetPuzzleInputOffline()
{
	return await Task.FromResult(@"6-10 s: snkscgszxsssscss
6-7 b: bbbbbxkb
2-4 n: nnnjn
1-2 j: jjjj
5-9 z: jgzzzqhbj
4-11 m: mfmmmpmjmkdr
12-15 t: twqrxttwttthtkxbz
8-9 z: ftzjzzzzr
17-18 h: cpkhssvpphzvprfnft
7-8 b: bjbbbbbb
4-5 p: pppppppppgppps
16-18 r: rrrrrrrrrrrrrrrrrr
9-16 v: vvvrpvbvvvvvvvvvwvvh
11-15 d: ddddddddddddddjd
9-14 g: ggbggghggggggggw
1-5 d: ddddbd
1-4 x: xxxwxxx
1-2 l: bdjjddlqg
1-4 b: lbbxb
15-16 f: ffffffffffffffmz
10-16 m: mmlmmmvmmmbhmmmq
4-15 v: vlfvvqphhjfvlgt
5-12 m: mmmmjmwmmmmcmmm
7-8 q: qqqqqqxkq
4-9 h: hhzhhhhhhhhhsh
3-7 t: thltdtjtstzrtwtt
6-7 k: kkkkkkk
1-5 q: jqwqd
4-13 x: xxxxxxxxxxxxxxxxxx
1-4 l: llfl
6-12 n: nnffnfnnmnffnx
4-6 m: xmvxnmpmm
5-7 m: mmmmbmmmmmmmmm
9-17 f: ffffflffbfffffcffff
4-10 k: kkklkkkkkhktkkbkzq
8-15 z: kdxxzzlhpzgbzjzz
2-5 q: qrqqbqqqqqqqkqq
3-5 t: zrttht
9-12 t: ttxgntjmvntctpfrt
2-3 k: kkkk
8-10 j: jjjjjjjjjj
2-9 k: vkwkhcqnk
9-10 t: ttttttthtt
4-6 b: bbbbbbbb
9-12 n: xnvnnvldhthlsn
2-4 w: wwwwwwj
6-10 t: tttttwttttvtt
3-10 j: jqjjjxjdjnjjjj
15-18 q: kqlncdqwclqpjzrbnq
7-8 p: gpwbjppp
3-13 m: mmmmlsmfvmhmmmm
7-10 s: wdshsrsgsl
8-16 f: fffffffxfffffffcf
16-18 s: ssskswhsvslwsssrsq
12-14 j: gjjjjkjgjkjhjvj
13-14 t: gtttvftwtgvhlt
6-7 v: vvvvvgbv
2-8 l: ssldslmvl
3-9 l: bflzllqkqlkll
8-9 n: rrnnnnnnsn
7-14 p: bqsrxgplkpdvbpkn
2-5 z: wzbclnsxt
2-4 k: knkxk
6-8 d: drddjddjdd
15-16 p: ztgptpfpcwppqrzppps
1-3 k: nmsqksv
7-10 n: pwhbcwnlznfnvrlnds
13-15 t: tttttttttttttttttt
10-12 b: bbbbbbdbbgfxbbbf
3-5 w: rwwwj
18-19 x: xxxxmxxxxwpxxxfxgln
1-4 g: lfsjtgggg
13-15 x: mxzgtxhrxjhxtnf
13-14 d: ddddddddddddlx
3-5 r: rrrtrrtmlr
1-7 t: thttttttttt
2-5 g: sngggj
8-9 n: tnnnnnnnn
6-10 w: wkwwjfwltk
12-18 n: nnnnnnnnnnnnnnsnnh
14-18 m: mmmmmmmmmmmmmmmmmmmm
5-15 v: fvvfrcqkvkggnpl
13-19 f: ffffffftfffdnffffpsf
13-15 k: kgkkkmkkkgftklb
4-6 h: hhhchvh
7-14 l: qmbdhdjbrglxql
13-17 w: kwwwwwwwwwwwdpwww
1-5 q: pqqqdqqqq
8-9 p: vhwphvpfp
2-4 h: hljmh
1-2 c: tmcc
3-5 f: dpnvwffhlp
3-5 m: mmmmmm
10-12 c: ngjnczmcscxc
2-4 x: mxxj
4-6 m: xbmkmm
1-6 l: kllllsblqhngl
11-18 x: xprkjcrxkgxxgwtbmx
4-6 k: vwxshkkkkbtfbhl
11-15 z: dzzkzjjzzzzzzzlmzbn
5-6 f: ffffnfffflfjff
3-6 d: ddddddbd
6-9 r: wrrrvrrrr
8-9 n: nnnnjnnnt
2-7 b: bxptdkctbrxfllpvj
3-4 x: hxxv
5-14 n: nrnnnlsnznnzrqnjxnp
1-3 w: wwww
9-12 x: xxmxxxxxxxxxtxx
10-14 j: jjnjjjjlvjkcsjjdllvj
4-6 w: wgwbwwww
10-12 t: ttqttttttttl
10-11 t: ttwtttttttv
9-15 t: ttttttttftttttttt
2-3 p: pfgp
2-4 z: brrksnvqjzwqjvjs
8-9 n: knnnftzjbqj
6-7 w: swjwwdwwwwwwwww
1-2 j: xjlrkjjztrjfpss
13-14 l: llllllllllllvlllllr
7-12 l: lllllllllllblllll
7-8 j: gqdcmjqh
3-9 g: gchkbvgvgw
15-17 b: bbbbcbbbgbbbbbmbg
1-7 h: qlmhhcdhhhhhhhhhh
2-15 c: ccccccccccccccscccc
1-2 q: xvch
3-9 w: wwwwwwxwww
2-4 x: jskx
3-7 t: btwsnvts
9-11 g: gkhgwctggbm
2-7 g: xvgwwltdvnzscbtqwb
1-11 k: kkqkpkkdkkkkkkkhkk
4-12 h: nbqlhjbqhxtnxlzlr
3-4 d: dwdd
8-9 k: kkkzbckklqqkhfkqkk
7-8 c: pcxmqdwc
2-4 v: qbvwvvnvvp
3-9 c: pfqcblwxcrmx
1-9 t: fwgtcrftktt
7-8 p: pppppppp
6-13 w: dnwfhwkjffpdwgzdf
10-14 k: kkkkkkhkkwkkkkkk
2-4 s: zscssddtpmqblmd
11-13 b: dbvzwthlcmbkb
1-4 k: kqlxwvbkckwzmqxvtcc
2-10 s: sxssssgsssxsssnss
3-9 w: nxrmwlpgw
10-13 w: wwsgwwwwwwwkw
9-13 v: vhvvwjvcvbvvg
5-7 n: fbvnjpt
3-4 x: xxxx
9-10 l: rlllmlllll
7-9 d: ddddddddhd
4-8 z: zzzhzzzf
11-12 m: mmmmmmmmmmkf
4-8 m: bmfzppcqttct
2-4 m: mfmcmmmcx
2-9 p: rppzgvshn
7-8 r: rrrrrrrrrrvr
6-7 p: hkltppp
7-10 m: mmmmmfmmtmmmpbmm
6-14 p: pppppppppppppxp
4-6 p: wbspppnlmc
2-4 n: xnfnl
2-5 q: nqkcqmvwp
2-3 d: ddkbkdjd
5-9 b: qxjbblbrb
14-16 b: bbbbbbbbbbbbbqbbb
5-6 p: dppppp
5-8 j: kxztnjjn
14-18 k: krkkkkckkkkmktkkkkd
7-8 n: nnngxnfpnn
16-17 c: ccmccccccccccccfcccc
1-3 g: wggg
1-2 c: cqcckc
2-8 g: gjwdkbds
10-17 s: hswqssmttskspdlkkss
14-16 b: bbbbbbbbbbbbpbbrbbbb
12-16 r: srrmcbrrcrzrdwzng
2-3 h: fcws
9-13 p: gkgpqpghpjbpz
9-10 m: mmmmmmmmmmm
3-4 b: brbb
2-3 p: gncvqdhp
2-7 g: gdggggggggggggg
2-7 j: jjjjjjrjqjjj
3-5 v: ltptjlntf
1-7 w: gwwwwwfww
7-10 z: zzzzzzmzzzz
10-12 x: xxhxxxxxxgxsxxxx
11-12 b: bbbbbbbbbbbbd
16-17 v: vvvvvvvvvvvvvvjht
1-4 x: bxxx
16-19 g: gggggggwggggggjgggg
5-10 q: qjpqqvlnkqxmlv
4-6 p: qrpffplvpp
7-9 r: rrrrrrgrb
2-3 g: bgjg
10-12 t: ttjttttnttdtt
2-4 g: dgng
11-12 r: rrmrrrlrtrrj
1-5 v: qvvvvvvvvvvvvvv
3-18 p: ftnfnpmjprmrzmhbnxj
10-12 w: dqnsjjxsqrwq
2-4 z: lzgkzsb
8-9 n: dwclxdtnndtpcgqmx
10-11 w: zjwdsphbbwlhp
2-9 d: zzprkgzczbs
14-19 c: gpjfrvsrcnbxbclctxc
1-9 f: fmhfvfffrfws
12-14 d: ddrddbddddddddhmdg
14-15 s: sslsssmsnssdxsj
2-10 v: ljppzjfvfnfp
1-2 z: qbwbzknrzzs
18-19 l: llllllllfllllllllll
2-3 p: ppgp
13-15 k: knkkkkkckkkkhkxk
3-6 v: vbjvmv
4-8 h: hmhcxfhg
12-14 v: vvngcvvvvkvgvs
2-3 j: xdjjrk
5-13 s: sssssrqsssssq
1-7 s: sssssssss
6-14 b: ptlvmbbrbxnvqbrmp
16-18 w: wwwswwnwwmwwwwwwwf
1-4 k: kkknkkkkk
1-4 g: ggrbk
9-11 r: rrrhrrrrrrrrr
11-13 x: xxxxxxxxxxxxnx
3-8 x: nsxvlvdfbkpxsgscn
12-15 h: hghhchvjhhhhlvhhhhh
11-12 n: nnnnnnnnnnjqn
10-13 r: jrzfzrzrqblmks
7-8 w: wwwwwwwh
3-4 k: kkbft
1-9 c: cccccjccccccn
2-7 r: rrvnrxrvrzsrbrs
3-10 l: llgdldmlplqlhdlll
4-8 m: mmzmbmgm
5-6 q: sfxqnftnbnqwq
5-6 v: vvvvgvvqv
9-14 h: dhmwrhzqqvhhhfhfhhht
4-7 p: jwwppvpklc
9-13 z: zzzzzzzzzpzzzx
13-14 l: fllklltlllllcphllll
12-15 m: htmbmqgljcmvmclgnm
9-10 b: bbbbbbbnbb
6-12 x: nxjbxxhxxxxgdxx
6-7 t: tttbwlk
8-11 q: fqqjtlswqgkqdqc
16-20 t: xplwqxbwtsfptbvtvcxt
3-4 k: kklkkkkkkxkkkk
3-9 m: kmmsvmpmxmgmb
6-12 j: jjtjjjjjjjjpjjwj
3-4 m: kkmbmzkx
7-8 f: gmfxlgfjtfst
1-3 w: wwwn
1-7 k: knkktkkn
13-16 v: vvvvvvvvvvvvvvvmvv
10-11 h: rhvdhnfhvtchlfhh
10-12 x: xgxwbqxkxxcwsfd
10-14 m: mmmrdxpcmcmmmkmmmmm
2-5 x: vvxpx
8-9 h: hhhhhhhmfh
16-19 j: jmwjjjjjjjjjjjjjjjz
2-3 r: sqrnr
14-19 p: ppppppppppppppppppk
2-5 w: wwwww
15-16 q: dppxtnhmxrhmncrqq
4-5 v: drhpp
1-4 p: pkhn
3-6 q: gwmrfwh
6-10 v: dlvvfhvvkb
1-8 q: qqqqqqqqqdqqqqqqqq
17-18 n: nnnnnnnnnxnnznnpnng
3-7 m: gmxzffwmbdm
12-14 m: dmzmcmmhjmqltm
3-16 w: drcbwtvqgbppbwzvm
8-10 d: ddbddddzdddddkpd
8-9 m: mmmmmmmmmmmm
1-3 l: glll
7-11 x: fxrxxdxxxqxnxx
6-7 d: ddddxgdd
7-8 g: hgggbggg
2-3 w: pwwtww
7-10 h: lhwbhjhzhx
3-14 b: bbbrvrbsfbnxrgqbbq
4-7 l: jzqkxlnpxlglfsll
6-7 b: hbpbbbb
2-4 w: pskwwxzpjvmwcnfr
13-15 m: mmmmmmmmxmpmxmmm
4-9 k: krxkzqzkkhrpqth
4-7 f: xfffkvfqzwhcfwkhq
4-10 q: qqqqqcqbqqq
14-15 s: lgszsdststlpgjbs
7-12 s: sspbsssskfns
7-8 d: cdddqpnd
13-15 p: ppppppppppppxppp
10-11 r: rrrfxrrrrrrrrr
10-12 z: zzzzzzzzzvzvzz
3-4 l: lllwll
7-9 p: ppppkpppqpppppsvx
3-4 k: kkkrk
4-5 v: zxmmvmhvr
14-15 r: rrrrrrrrrrrrrfjr
6-10 b: vwbgbbbbdbqsbb
5-7 j: jsjjjkv
3-4 m: tzmhr
11-13 r: rrrrrrrrrrqrhrr
1-4 s: psqmcssnk
5-6 z: zdkzzzz
3-5 p: cnpmbtknqdppmcjpzvcn
13-14 g: ggggkggggmtggd
14-17 c: nxmzcczccnvdcxpcmb
6-10 w: wlwwbdwwwwwwww
9-17 l: llllllllllllllllll
2-12 j: jpjdjjjzmjxj
1-3 n: szjntnnl
7-8 l: dpxlmhlbts
5-16 s: sssssssssssssssrs
1-6 m: pmqvlc
7-15 f: ffffffffqfkfffdxff
10-11 w: wwwwwwwwwwswwww
7-12 p: tkppvfpwksrp
4-7 f: fdjdgdvsksbfbnjkspc
4-11 b: bjmvfrmlmlbndl
1-3 r: rrrnxhgbwr
5-10 h: xhhmhhhlhbh
10-11 h: hghhhhhhdlhhh
5-6 g: gptglg
9-11 t: wtgtxtttqtmttt
5-11 f: jxqffhfsfmz
4-7 f: frjffbf
1-15 m: mmmmmmmmxmmmmmmmm
1-12 d: drwlbpdbzdgdjpnzmj
9-14 n: nfnmktjnncnnnln
1-2 h: pshhjhhhhf
2-4 t: tgttttttfb
2-4 w: dwpwhnxbf
7-11 b: vbcbzhbwhpb
4-5 k: hknck
5-12 m: mmmmtdmmmmmmmm
5-7 w: qwflwxq
2-5 g: jdnxdlclplvb
5-7 t: ttrtttttkr
8-18 l: lwscjwlmdlzlllnsllpw
2-8 c: cccxtccchbrkr
1-3 q: qqtqqqqq
3-13 d: dddddddbddddddd
1-7 r: jkpzrpfnrgpkc
9-10 t: ttttttttttt
11-12 w: wjwplwwwwwmw
9-12 r: rpsvrhrbnrwqch
6-11 p: zpzbpkpmtnptsnpbswc
4-6 t: jhzstt
3-4 t: ddpkcgpzhd
4-6 s: cvzshjfrsslxnslqddwt
1-3 c: cgsczhl
1-4 d: lddqdqd
6-7 v: vvvvvvb
5-8 w: wwwwwwwwww
5-11 p: ddswpbpppsqpp
5-6 x: dfzxxxhhqjvj
3-7 m: mmmmmmmmmm
4-8 g: ggggggggg
5-6 j: jjcjjn
5-6 n: nndtns
4-5 t: ltxkdpst
2-8 b: ldwkbzbxgpbbbb
11-12 w: wwqwdqwwwqhvwww
15-17 k: klkcxqbwrktxcmqlnb
5-6 k: tkqhkkkkrkjfd
12-13 x: nxxxrjxxxdjlxxbt
9-12 m: mmzmmmrmmfmgmmmmb
2-5 v: tkbhvlvp
12-14 v: dvbvvvvhrcvvvxxvvvvv
14-16 x: xxxxxxxxxxxxxrxxxx
6-7 v: xvswnvvm
6-9 c: vcpcksxwbdlc
5-11 s: sssssjssssrsdjsssq
6-16 j: jjjjjmjjjjjjjjjnj
8-12 g: ggggwggggggnggg
4-5 c: ccczk
14-15 l: lllllllllllllkm
10-11 r: rrrrrrrrrrrrr
3-5 n: dwnvnlj
2-4 x: xdxxxx
5-6 j: jjjjjjj
3-9 k: kkkkkhlrkktt
3-7 t: stqtgfdprtqjsgznrtjh
11-16 n: hsnnnnnnnnfnvnpqnnn
13-16 v: kdvbvxvvtvhvvvvq
1-3 v: vwpvkvdpxgc
14-17 v: vvvvvvvvvvvvvnvvhv
14-15 m: mmmmmmmmmmmmmtm
6-10 m: mmmmmhmmmm
5-8 t: tttjrttdsttfttwstf
6-7 c: ccqcvcc
2-5 v: vvvvvv
8-16 c: cccccccccwcpcccmcccc
4-5 t: ztvttktttttt
10-11 n: rnmnnnnnnnnnnnnpt
5-6 g: lgsggggg
15-18 s: lcsmgkjqzdpcgvsrng
2-6 p: wwpppp
9-10 v: vvvvsvvvmvv
6-11 c: qrmdjxzsmxcmcccgrr
17-18 b: bbbbbbbbbbbbbbbbbbbb
6-10 t: thtxgtpxwt
2-8 f: xkgbrpqfsrhhbnfpdg
3-8 c: gqkkvgkcqfwdc
5-6 c: jjcsjf
8-16 q: fbwdmlwljqqcrqsq
3-10 m: mjmmsmmmmmmcmm
5-15 x: xmrvcsjwxxdpsrxzcrzj
3-7 x: rxngzxxg
17-19 z: mmvfgzpmbvzsrmkgmmmb
3-4 z: zdzz
4-5 v: vzcvb
3-11 z: tzllpgzzmwxznh
8-11 x: ptgvnbxzsxwdb
2-3 r: rrrrr
6-10 b: bbmbbbbbbb
6-11 q: wvmqrzrllhxfzmpkp
13-17 v: vvrgvvsvvcqkvvvvbvvw
16-18 p: ppppppppnppgppppclp
13-15 g: gglggggggngggggggggg
15-17 b: bbbbbbbbbbbbbbbbb
3-6 t: tpwzktlzkdt
2-3 m: lmvtnfjzmm
1-7 j: jzjjfjx
15-17 r: rtfdnhrrhrrdcswrl
1-3 d: gdfdmddddwdddlsd
3-4 r: qrtr
10-11 m: mmmmmmmmmkc
2-5 n: gntnnnncc
9-14 b: bbbbbbbbbbbbbb
10-13 f: fxfffznffffzwffflz
5-12 j: vjjrjjjjngjjjjm
6-8 k: kkkrkklkkkkkkk
5-7 r: rrhzsxrjjw
17-18 g: gggggggggggggggggf
2-3 h: ghhvrh
1-3 j: hjjxjjjj
3-5 q: gbqnqkprckxqglkhw
17-18 n: ngnnnnnqnnnnnnnnnnnn
2-3 m: xlhmmq
6-7 p: kvvphgj
9-12 k: kpkzkkzkkkkkbwk
9-10 k: kkrkkkkkmt
5-10 t: tttttttttttttttt
10-11 l: ztdvlllzfltlwlglkhcj
7-12 t: bttttqtqttttttttg
3-4 z: xzvb
5-10 h: lhcdhkhhhhb
1-6 z: jqzzqzzzzzzzzzzzzz
6-7 x: qxxxxtxz
13-14 g: gggngggggggrgsgg
1-2 t: tttt
11-15 w: hpwhwmwlkbwtwmwlj
8-10 r: rnrhrrmprnrrr
5-12 z: rshzhwgzhfjb
15-16 s: sssqssssssssmsss
9-12 z: zdzzzzzzkzmz
10-12 c: mfgpskncfcfctjmt
5-10 p: sppwnpdpptppwdppppp
3-14 q: mnzfgfmvmsdlqg
1-13 s: sssssssfssssbsss
6-8 d: ddddddddd
2-5 j: vsbbjh
14-16 m: nmklmsrpjxwpdbmj
3-8 v: rfvvvjqv
18-20 p: pppppppppqhpflppbppp
7-11 x: xxxxxxwxxxx
3-4 l: llmvlll
8-9 w: grmvwtwbz
2-11 m: mmmmmmqmmmsmmmmmmmmm
6-13 h: hhhhhrshshhhlhhhh
3-12 t: tnttblttttcvrtttx
5-18 f: cfffcffvgffffrmlfx
1-3 n: rnjnnnnnnnnnnnnnnn
1-2 w: smmdq
1-5 v: vvvvvv
5-15 s: tssssscssffhsswssss
3-11 b: bbbbbbbbsbkbbbr
13-15 j: xjjpjjcjjjjjjcj
5-10 g: bvjvgpzgdgkmmzwnwrxz
2-7 q: qqqqqrq
10-12 d: fddddbdddxdqpd
5-7 c: hsccjccrlm
11-15 r: nrrrlrrvrdlrprw
13-14 r: drrtbrrrrrrrrcrrr
8-10 c: ccccxcchfjcccccxpc
8-9 s: sssssssss
1-10 r: rvlgkrrrrm
8-13 w: jwbwcwmwwvwwwwww
7-12 k: fxkkcnkkbvkxbkphx
7-8 l: llllmlvll
11-15 q: qdjpqwgfqjdqnnq
8-9 m: mmmmmmmvmmm
6-7 k: kkkksmkb
4-6 h: hhhlhhhhfhhhhhh
2-5 k: xzjlwb
3-12 j: sjwqrjzjgqrj
5-18 p: ppppppppppppppppphpp
1-3 g: gggrggggg
14-15 n: nnnnnnnnnnxnnhnnn
19-20 d: jkpzsxwsddzccjdkcptj
2-4 v: wpdz
1-8 w: dwjtngwwwrwhp
13-15 t: tttttctttttxvfrt
6-11 h: ksvshqhhdth
8-9 k: khfkdkppl
11-12 d: whlmcdmfgfddd
11-12 p: htvxpkfngthz
6-9 v: vqvmvvbbv
5-8 m: lghmmmrmmw
14-16 q: dtmqqrqqqqqgpgqtqr
2-11 f: bfjskxzlgvfml
10-19 p: kpppppppphppppppppp
5-7 j: rfbpzmjtjj
9-10 p: kpppppppqpp
3-15 k: hgkgrqblnjmsbvrghzdk
6-7 r: rrtwrwlfrswwr
3-4 k: fkkdv
12-20 g: ggggggggkggggggggkgh
3-5 x: xxxxpxxxxxxxxxb
8-10 k: kkkkkkkzkh
4-10 q: qqqmqqqqqcqq
4-12 t: ttgtqblzqzpttcxdtfn
18-20 s: sssbbsscsjvslsvsssss
3-6 x: xxxxxxx
4-5 t: tttttt
5-7 q: xqqqqqqqxkqqqqqqqtqq
2-4 s: zsvq
6-7 b: mmbcklx
1-13 z: zzfzkshpslwcn
1-14 d: ddpddtdddddmmf
8-13 j: jjjjjjjjjjjjjjjjjz
5-6 c: cjjlxb
10-12 v: vvvvvvtvvmvv
2-3 b: wfbbg
1-10 l: llllllllllllllllll
5-10 d: hdbhdgxcjd
10-13 t: ttttttttttttnt
5-6 h: vhmhhh
16-17 x: xxxxxxxxxxxxxxxsqx
6-14 g: gzggggzhggggzgg
15-20 f: ffbfxffffvfffffffhfd
2-3 d: xdvw
5-7 g: zgggjgq
2-12 g: ggggggggmgggggg
6-8 h: hhhhhhphhhlhjhhxfh
3-10 j: knjklstqxwcsjf
2-3 h: hvnwjxhpsc
7-8 w: wwwlwwgw
14-16 s: chgtpswssxsqtwzrsqt
5-6 d: zdbdkl
3-4 p: lwkpbrbp
8-14 c: cbhtccjmrccrcp
2-3 s: tctflmgdtsjjfxpl
3-4 g: gggjkctwdsgl
2-4 h: ghbh
4-13 h: fczphhvflghhhd
3-10 x: jkzhgljwsblcrmbwfx
12-13 p: npfgppprzpppc
7-12 l: sqbplmqnlmwph
1-8 p: hpppvpprppp
12-18 n: nhbznznxncnkcchscl
9-10 g: grjxmgzpgk
6-7 g: rcmkggggggg
1-7 b: bbbbbbbb
2-3 t: ttftzqt
8-10 l: twbjlnblhck
1-2 c: cvbc
4-9 d: mfpdddsnd
5-8 f: flpvbdrfl
7-12 s: rhspsxlbpsmsclzrdsfc
2-4 h: vhhh
1-10 k: bhkkkkkkxkkkzk
5-15 q: qqqqqqqqqqqqdqdqql
12-15 c: ljvcklwjvngfgfgrjsv
8-10 w: pwwtpbwwvwwrwww
5-13 b: tbjmbfmknjhbb
1-2 v: cssd
2-5 s: ssssss
3-4 h: bhhxxhfh
3-5 p: pfppp
13-20 l: lcxxllcfjmllclljllfl
2-4 p: sqpzk
2-4 l: xlllb
1-7 t: ttttttrttttrttttttxt
10-12 m: bwmmghzmqmmpmj
5-8 l: jtlljpql
5-6 d: lddddd
6-8 c: nljczccdwvnmrlqvlsc
8-9 d: dzdddcddt
10-11 z: zzzzzzzzmqj
3-4 s: msssss
3-5 z: xzvdzbzt
2-18 v: bvcbpwkbdmclbnbmsv
9-12 b: jrcccsndstzbxprkvtq
3-11 n: vlntglzvvcnngn
3-8 v: rpgckwptlvdqsrqqt
6-11 q: qdqdkqvkvhdrdqm
9-12 b: khbmbgbbvbqb
9-10 g: gtggggggczgg
3-5 c: zqctcs
15-18 z: kbzsdhbbzxfzzqdjzc
7-8 g: ggggggzx
9-10 s: sswssrssqms
14-17 g: ggggcggggggggpggcgg
10-15 g: qgzmbkjlggrhgkg
9-11 j: jjjjjjjjqqjjjjjj
5-6 c: cgcdcchcccbcc
2-4 g: gggg
5-13 h: plkhhrmxhxhmh
11-16 v: vkkqrvbvbcvvnvvvvv
6-7 c: rlfmqphqrhqkhch
3-5 z: hzspz
8-9 d: kddmdddpdvddln
5-11 k: wkqkcfkpvnkvh
4-7 r: fnzzwxrxr
15-16 r: rrrrrrrrrrrrrrwr
2-19 f: fvffffffffffffffffwf
9-11 v: hbvbvvgcvvvj
2-4 m: mrxpv
13-14 z: zztzgzzpzzzzzg
4-10 t: qtvtcrfmlkrgtwsvwtw
3-7 g: ggggggfgggggggg
5-8 c: ccccfcccnmccc
6-12 z: bzfcjzdznzwzrzbzzqrn
14-15 c: ccccccccccccczkccccc
3-4 j: jjjjjjf
1-2 x: kxxxx
3-4 s: sksj
17-19 c: hvchccvccdxgccnxdcc
3-6 r: trrrrrrr
10-11 c: ckcjzcrzcbc
1-7 p: pmqplfpvgq
3-4 h: hhmx
5-6 n: nnwndln
5-10 v: bkkvfgvqwdt
7-14 h: hkjlwvhdnhxhwcnhs
4-12 f: xxwfjfcwslrfzrxfkxj
2-3 c: ccccc
4-13 k: kkkdkkkkkkkkkkk
8-10 b: mqlljkpbbbxbrbfx
1-4 p: pppp
14-17 n: nnnnnnnnnnnnnnnngnn
5-6 d: dddddddvw
9-10 r: rjtrrrmqrrrzrrrrjrrm
7-11 x: bxxxxxrwxpmn
13-14 w: gwmwwwlwwjwjwx
2-4 d: dddddvddd
7-9 p: pjmdppgpspcslh
13-16 l: tllllzllpvllvlzd
9-11 q: qzmwqqzqtqqq
4-5 d: dvdngdd
9-11 j: xxxvjrmgjpk
3-4 c: rvvcn
15-16 r: rxvmlslkpmqdqtdd
2-5 b: sbflb
4-5 w: wntpw
8-16 n: nnnnnnnhnqnnnnnnn
5-6 n: nnnnnnn
2-5 q: bsjfhq
6-18 r: prrrqkmrrrvbrrrrdfrv
3-5 g: xnxlp
4-11 s: jsstsssjssfssss
14-16 d: dddddddddsdddddd
18-19 n: vgngvbhdjfrbnznhhjzn
11-13 f: ffffffffffgfgf
5-11 n: dbgvngchnkngt
3-4 f: gsff
2-4 r: rfdrlznkzg
10-18 z: zzgzwzzzzzzdzzmzhzzn
4-5 s: qscmbssss
11-15 x: xbxxxxgxxxbxxzw
2-10 h: dkrnxknmthcv
12-13 b: bbbbvbsbbbbgcbnb
4-5 m: mmlmmsmmh
3-6 j: njrjjkcr
10-12 x: xxxxwdnxxxxx
14-16 g: hggggggggngggggg
8-9 x: gjqfxxxtxxxb
16-17 f: ffffffffjffkffffmffb
2-8 z: tsktkzfxntrv
2-6 v: hvvswd
1-2 w: xddl
2-6 k: svwvvkqmzwjkx
9-12 p: ppppppppbppspppb
12-19 m: mdjmlhsmxmwcmmmmmmm
3-5 x: rxjxb
17-18 r: rrrrrrrrrrrrrrrrwk
2-9 b: cbfbqcfwbmwd
1-11 h: hhhhhbhhhhmvhhhh
2-3 j: jkjjgjhxj
5-6 f: fffffffffhf
17-18 j: jprvtszvgsbtxlrhljsz
1-4 m: mmhmmmp
2-6 p: xvfkpkc
1-2 f: xqtfcf
1-5 r: brrrrrr
7-10 w: wwhwwwdwwj
1-4 w: vwwdh
1-3 f: hnpvgfwth
10-12 k: kkkkkkkkkdkq
5-13 r: rrpqrrvrqrswzr
9-17 x: xjxxvxvbtxxxtpxpx
12-13 j: njrjkcjgbjjnj
2-4 l: lvll
12-17 p: dpppprpbppnvpppprp
4-18 b: zftbmbxgzfzdvdnvhb
12-16 r: lcqgqjthprlxrzrrx
2-7 m: msclccmxhsmf
3-4 b: bfkb
2-6 k: skfgrk
4-5 q: qqqhhx
6-8 c: cccmvcch
16-17 l: bxnlvbvwzvfvbcmxl
7-12 c: cccccccccccc
6-7 b: bbbbjsjbbbs
2-7 q: phxnfxqrqv
4-5 h: hhhhhh
9-15 n: nqnnglsjnnghxrn
3-4 h: hkkh
5-11 r: rlsjvrrrrrl
5-7 b: bbbbzbwbbbb
2-3 f: qczff
8-14 c: fccqccccccclccccck
1-8 r: rrbfmjsr
4-5 p: dpphz
11-13 d: wdmwkcqddrdvdz
8-15 h: hhhhhhhhhhhhhhhhh
6-10 l: dhgdclhlkltnc
14-15 t: tttntttnthtttzw
4-6 p: pppppdp
13-14 l: dvlnvlgtbpnhll
11-12 s: brsqgfsnpmwskhdnm
6-7 j: httjvjj
2-14 w: wwwfwjzwrzfwnwjwwm
8-9 w: wwrwwwwgt
2-5 r: dvrwb
7-9 b: wwvqbsbjb
1-12 l: lljxlbslwlgn
11-12 m: mmmmmmhmmmwbmkmmt
10-11 l: lblllmllldl
3-9 w: wwpwwwwbfwwwm
9-10 q: pcrqfqlskz
7-9 l: llvlllblklllx
6-7 g: qgggjmwg
5-10 v: vvvvvxbrvvp
9-10 d: hqddgkkdrpdd
17-18 q: qqqqqqqlqqqqqqqqdt
6-10 h: hspnhhzldxphdh
8-13 l: vvvscdnlblllml
6-12 p: ppkrprpxwpppwx
4-5 k: tkslb
7-8 d: hdjdhnzdd
9-10 x: wkxtblgxxjxxlqnfxxlx
8-9 g: rggggggdk
10-20 d: kcgdtbbswwdtvgdgxfwd
3-4 g: gggggg
16-17 l: llnzlqllllzllllmllll
4-10 r: nsrrrbzrfzcrrzrrdqk
4-6 k: kkkkkpkk
4-8 n: nnnmntnnrnnn
12-14 l: lllllllllwlqllll
3-6 r: rrrrrrr
1-6 s: ssskcshsxtd
7-15 d: ndrbdnntdmkddxd
9-10 j: pjjjjgjsjhjj
7-10 k: pkbkkkkkgkq
4-8 m: mmxmmmdmmmmm
9-13 c: ngjcrcccvbcvqdjmph
3-5 q: qqqqqq
7-10 s: fcssnsssssslxspr
3-5 k: kkkkvv
5-10 f: tlbcvgwfzlf
5-9 x: xxxxqxxxx
2-10 q: qrprhbrhjhb
3-4 g: gggmgg
8-10 j: jjjjjjjgjpjjj
2-4 v: dvzvvtfm
7-12 q: zvzqprjhqdcqfzr
12-13 f: ffffffffffffqf
2-3 f: fffsdwq
10-11 z: ztzzjzjzzzlzzz
5-7 k: kkkkqtkkkkk
6-9 z: dfbzhgsrzsp
2-4 b: wpqb
9-15 c: cwchcdhxlqzccxbb
8-11 q: qqxptqqvqrgqg
5-7 t: ttttztcvtjtkts
2-6 n: nnbmdnjxclwkffrnxff
3-7 p: pppppph
9-12 d: xhmfndzcddfddvgddf
1-5 h: hthmhvlthhhhh
6-7 m: mmmmmmm
6-7 j: jjjvjjjrj
1-5 q: mqnqwqqqqqjq
10-11 b: bmbbbdbpbbbbzbb
1-4 k: gvccvdltkwcdd
12-16 s: sssssssssssjssshs
4-10 k: wzvlkmdhcklhdp
10-13 z: zzzzzzzzzfzzj
6-12 g: bmzmvvggpgtm
3-11 m: nvcpfgvnsqmwxmmz
1-5 n: dnwnnnnnnnbndnnn
4-5 h: lhhhh
4-5 g: gggdg
2-5 h: xthqhfj
2-4 f: lfkf
4-6 k: rqbhrtzktmvmrxck
4-5 q: jqdsc
10-11 h: hhhhhhhhhvjh
2-17 r: rrrrrrrprwrrrfjrr
16-17 b: bbbbbbbbbbbbbbbbhbbb
3-5 z: pkvzzfrljrjctw
13-14 w: wwwwwwwjwwwwww
8-10 d: dddddddldzpq
1-4 b: sbbgb
2-10 d: vnhpzmvpcddhs
8-15 t: zftpwtrtqjqtfntp
11-12 j: djjjjjjjcjjcj
4-7 r: jrrtrrrvmzzrrvsl
2-4 r: rpkp
3-4 b: qbxc
10-11 w: wwwwwwfzkdmnwwv
6-14 z: mztxzzztmzwzzqvm
12-14 w: wwwwwwmsgwdwsqwjwww
6-10 f: zfhqjfhnjfdvwsfftf
2-11 q: mwbbqdncdfq
8-11 v: zvtvvwvfvvq
6-8 n: xnwhzmdskwhn
8-15 q: qqqqkqqqqqqqqqst
1-4 n: nnnnn
5-18 c: sqczchcwcccclccccccc
3-4 j: klgr
11-12 m: mmmmmmmmmmmm
2-3 d: qdxfmqwbmdnvj
1-5 m: cmmmm
6-7 l: llllllll
1-9 m: zmmmmmmmlmmmmmmm
9-11 m: dwspwrmjsxpc
5-6 p: qpppfz
10-19 t: fvtphwzsptqzntbkxqt
7-9 m: mpcmpmmmvptmm
3-9 h: hhhpqqwhhtm
11-16 p: pppppppppppppppvp
1-9 k: ktkklkkkkkkk
10-17 q: rthtqvgspqkvfkgkqfhj
11-14 g: ggxgggggxggzggcnggg
3-4 t: tttt
9-10 t: sqtbdttthtttm
1-4 t: ttkbgdzztbxd
3-8 f: gxfcrrsfntftvffnfqff
9-11 q: qqqqqqqjlqqq
12-13 v: vvvvvvvvvvvvk
7-11 b: nbxbbbsmbtkb
7-8 k: kkkkkknn
4-6 j: jjjjlv
13-16 m: mmcmmmmmmmmmmmmvs
7-9 k: kdkkkkrkgkk
1-4 c: crcdlrdbzc
1-16 k: kkkkkkkkkkgmkkktkkk
2-12 l: llllrlllllllll
4-9 g: gggbkgpgz
6-7 q: qqqqqqjq
6-7 v: hvvvvpm
10-14 t: ttfxmqtgtttttbtct
5-7 h: hwhhfrnch
4-13 w: zdlrqvxwwzsfrfq
4-5 h: hhhshhhh
2-4 n: vhjfnz
5-6 s: sssssss
11-13 n: nnwrnnnlnngnn
3-4 s: wbss
3-4 s: wnss
16-17 p: ppfprptkpmzkbjppp
2-4 v: pvxv
8-9 w: swwwwwwhwwnwwwxj
4-6 s: pzhkvss
4-5 x: wnxpx
4-5 f: fsfwp
4-5 z: zzdjz
3-6 v: vnvvvvvvvvvvv
5-6 f: wfxfff
4-7 z: zzzqfzz
3-5 q: qqjqsqqqf
3-7 w: kwwkmww
6-7 h: hhhhhhgh
2-5 v: vvbzvvkn
8-15 r: svrqpqrgrrhmzbms
9-17 n: jnnnncnnnnnxnnnnnp
5-6 n: dgnhsc
5-7 l: lplltbv
4-6 n: mmrnsbcqr
7-8 w: wwjwwwwww
1-16 c: bccccccfcccccccdcc
6-9 l: sjnlmxwllg
3-9 q: cqvhkwhtstwrl
5-9 h: khvxhhhgfchhknhhhz
8-9 c: ccccccccdc
2-19 n: jjxbmbwmnqbblfbgzsz
3-4 p: pppp
1-3 b: jzxbbb
3-6 h: hhhgjhhw
2-8 f: vfxftzkmlzk
11-19 h: mmdptdzhwdbjhvkccrhk
4-14 s: sssvsdpsssssspns
11-12 f: fffffffflfbk
2-13 h: nhbgtbjvbpmrnhf
1-3 t: ttttttttttttttttttm
3-4 t: tsttr
2-9 n: fnkknptqn
1-8 j: qjpjjjjjjtpxjqjw
2-12 c: clccccccccckccc
18-19 f: dpftffzcfhqffddfpff
1-4 j: trjj
9-11 z: zwzmzzczsdd
5-8 g: vrpbggfn
2-5 k: qksvzkj
2-4 f: wfdfjlfwmjrdmxx
4-12 l: bnplnlgqcwql
13-14 n: nqlfdnnnnnnnvbnwnlh
4-8 l: dgxhsrql
10-11 k: qvwcrkxtkjxlq
5-6 g: ckgggg
6-14 h: xbhhvzvxbhhhhhbhkzhh
6-9 w: whwdwrxgc
7-9 b: bbrbnjbfb
7-8 w: brwwkfvwwwww
2-11 g: gmggghngggg
12-17 l: bgslljzntbmvtkbgllgg
12-18 g: gggggggggggkggggggg
1-3 l: gllllllll
14-16 k: jkkqkkgkrkvxkkkkskgb
2-3 v: vljvgnvm
7-8 r: jrjvrprr
7-8 f: xxffrnff
2-18 j: jhjjjjjjjjjtjjfjjpjr
8-9 q: rfllhmnqtrkv
2-3 n: lnndv
2-15 s: hzzsrprnnjlwdfs
1-5 q: vqqqq
9-18 b: gxbpbbppbrbbnlkmbb
2-13 b: bbbbbbbbbbbbpb
6-7 t: mtrftthtttftttztttst
1-7 z: nfzzzzvzzczzzzzzzz
4-12 m: mmmcmmmmmmmmmm
9-11 p: jpswppqbmpfpzpg
10-11 c: ccccccpcccc
2-6 t: ztscdrkxxctdft
3-13 q: mqfqqqqjqqfqdqqq
16-20 z: zzjcxdmzgzzzppbtztzz
5-15 w: wwwpwhwqcwwwwwgw
2-4 p: pczp
5-7 d: ddddmdfd
2-3 f: fftc
1-3 v: vvmv
11-15 k: tjkcvkkkkgkzkkxqv
4-6 b: vdkvbn
7-8 c: wbcjhswc
9-10 l: lllbqrllll
4-5 s: sjnlw
12-14 j: mjtmzfjjtsgvgtq
1-3 l: llrllml
12-13 d: dngddlqdtgdcd
3-5 l: cblhld
3-4 r: trrq
1-3 c: kcccc
9-10 g: bgbgjggpvgpgpggg
3-6 d: szwlfm
13-14 f: ffffffffffffzfff
6-7 d: ddddddddddnnddddr
7-16 h: xmbpwmhsznmldhnxflc
4-6 q: qqqnqqqg
2-7 t: ttwbpmnthmjr
8-16 x: xbcxxbwxxrpxnfxd
2-3 d: dngdd
9-10 n: qkxfdljnnl
4-5 f: ftfffff
12-15 n: nnnnnncnnnnnnnsnn
1-2 d: dkdd
2-5 v: vvvvgv
1-14 v: jvvvvvvvvvvvvmvvv
5-6 r: rrrrrr
2-3 b: bnvbbbtbjgxfchnkhcjb
1-14 g: wjggxgggggggxgmrvcg
1-6 x: bhvxhxxxx
1-2 r: rprr
6-7 c: cccccccqc
4-8 b: bbgplbbcdtbbdbgbbhbz
1-4 w: wjgw
1-3 h: zhzzt
2-11 j: sjjrtjkjhjj
6-7 m: mlmrrmm");
}