package main

import "core:fmt"
import "core:crypto/legacy/md5"

main :: proc(){
	secret_key := "ckczppom"
	number := 1
	for {

		text := fmt.tprintf("%s%d", secret_key, number)
		ctx : md5.Context
		md5.init(&ctx)
		md5.update(&ctx, transmute([]u8)text)
		digest:[md5.DIGEST_SIZE]u8
		md5.final(&ctx, digest[:])
		// PART 1
		// if digest[0] == 0 && digest[1] == 0 && digest[2] < 16{
		// 	fmt.println(number)
		// 	fmt.printfln("%x", digest)
		// 	return
		// }


		//PART 2
		if digest[0] == 0 && digest[1] == 0 && digest[2] == 0{
			fmt.println(number)
			fmt.printfln("%x", digest)
			return
		}

		number += 1
	}
}
